using AutoMapper;
using Netactica.Data;
using Netactica.Models;
using Netactica.Models.Exceptions;
using Netactica.Services.Request;
using Netactica.Services.Response;
using Netactica.Tools;
using Netactica.Tools.StringTools;
using System;
using System.Collections.Generic;

namespace Netactica.Services
{
    /// <summary>
    /// Clase de negocio para la entidad Usuario
    /// </summary>
    public class UsuarioServices : BaseServices, IUsuarioServices, IDisposable
    {
        #region [Propiedades]

        /// <summary>
        /// Acceso a datos a la entidad Usuario
        /// </summary>
        private readonly IUsuariosData _data;

        /// <summary>
        /// Acceso a datos informacion complementaria
        /// </summary>
        private readonly IUsuarioInfoData _dataInfoUser;

        /// <summary>
        /// Acceso a datos a la tabla UsuariosEstado
        /// </summary>
        private readonly IUsuariosEstadoData _dataEstados;

        #endregion [Propiedades]

        #region [Constructor]

        /// <summary>
        /// Crear constructor de negocio con el acceso de datos a Usuario
        /// </summary>
        /// <param name="data">acceso a datos usuarios</param>
        /// <param name="dataInfoUser">acceso a datos informacion complementaria</param>
        /// <param name="dataEstados">acceso a datos la tabla UsuariosEstado</param>
        public UsuarioServices(IUsuariosData data, IUsuarioInfoData dataInfoUser, IUsuariosEstadoData dataEstados)
        {
            _data = data;
            _dataInfoUser = dataInfoUser;
            _dataEstados = dataEstados;
        }

        #endregion [Constructor]

        #region [Acceso a Datos de Usuarios]

        /// <summary>
        /// Consulta el listado de usuarios de acuerdo al rol del usuario que realice la consulta
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>List UsuariosListadoResponse</returns>
        public ResponseModel ConsultarUsuariosAdministrador(UsuariosFiltroRequest request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var filtro = Mapper.Map<UsuariosFiltroRequest, UsuarioFiltro>(request);

                Validator<UsuarioFiltro, UsersFilterValidator>(filtro);

                bool isSuperAdmon = _data.IsRolAdmon(filtro.Rol);

                var query = isSuperAdmon ? _data.ConsultarUsuariosConsultaSuperAdmon(filtro) :
                    _data.ConsultarUsuariosConsultaAdmonCliente(filtro);

                var usuarios = Mapper.Map<List<UsuariosListado>, List<UsuariosListadoResponse>>(query);

                response.SuccesCall(usuarios, "Consulta cargada correctamente");
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ConsultarUsuariosAdministrador)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuariosAdministrador)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta el usuario por id
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <returns>UsuarioResponse</returns>
        public ResponseModel ConsultarUsuarioPorId(Guid usuarioId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var user = _data.ConsultarUsuario(usuarioId);
                if (user != null)
                {
                    var userResponse = Mapper.Map<Usuario, UsuarioResponse>(user);
                    response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} consultado correctamente");
                }
                else
                {
                    response.NotFound("No se encuentra el usuario por id");
                }
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ConsultarUsuarioPorId)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioPorId)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta el usuario por nombre de usuario
        /// </summary>
        /// <param name="nombreUsuario">nombre de usuario</param>
        /// <returns>UsuarioResponse</returns>
        public ResponseModel ConsultarUsuarioPorNombre(string nombreUsuario)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var user = _data.ConsultarUsuario(nombreUsuario: nombreUsuario);
                if (user != null)
                {
                    var userResponse = Mapper.Map<Usuario, UsuarioResponse>(user);
                    response.SuccesCall(userResponse, $" Usuario con nombre '{userResponse.Nombre}' consultado correctamente");
                }
                else
                {
                    response.NotFound($"No se encuentra el usuario por nombre {nombreUsuario}");
                }
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ConsultarUsuarioPorNombre)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioPorNombre)}");
            }
            return response;
        }

        /// <summary>
        /// Guardar un usuario nuevo en la base de datos
        /// </summary>
        /// <param name="userResponse">UsuarioResponse usuario nuevo a guardar en BD</param>
        /// <returns>UsuarioResponse</returns>
        public ResponseModel GuardarUsuario(UsuarioResponse userResponse)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuario = Mapper.Map<UsuarioResponse, Usuario>(userResponse);

                Validator<Usuario, UsersValidator>(usuario);

                ///Para insertar la contraseña tiene que estar en base 64
                if (!usuario.Pw.IsEmpty() && usuario.Pw.IsBase64())
                {
                    string pwDecodeBase64 = usuario.Pw.Base64Decode();
                    string key = "KeyDecript".ReadAppConfig();
                    string pwEncode = pwDecodeBase64.Encode(key);
                    usuario.Pw = pwEncode;
                }

                var newUser = _data.GuardarUsuario(usuario);
                userResponse = Mapper.Map<Usuario, UsuarioResponse>(newUser);
                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} creado correctamente");
            }
            catch (NotFoundException ex)
            {
                response.NotFound(ex);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(GuardarUsuario)}", ex);
                response.Fail(ex, $"Error en => {nameof(GuardarUsuario)}");
            }
            return response;
        }

        /// <summary>
        /// Modifica la contraseña de un usuario por id de usuario
        /// las contraseñas tienen que coincidir Password y PasswordConfirm
        /// </summary>
        /// <param name="userResponse">UsuarioResponse contraseña a modificar</param>
        /// <returns>UsuarioResponse</returns>
        public ResponseModel ModificarPassword(UsuarioResponse userResponse)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (userResponse.Password.IsEmpty())
                    throw new BusinessException("La contraseña no puede ser null");

                if (!userResponse.Password.IsBase64())
                    throw new BusinessException("La contraseña tiene que estar en base 64");

                if (userResponse.Password != userResponse.PasswordConfirm)
                    throw new BusinessException("Las contraseñas no coinciden");

                var usuario = Mapper.Map<UsuarioResponse, Usuario>(userResponse);

                usuario = _data.ModificarPassword(usuario);
                userResponse = Mapper.Map<Usuario, UsuarioResponse>(usuario);

                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} guardado correctamente");
            }
            catch (NotFoundException ex)
            {
                response.NotFound(ex);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ModificarPassword)}", ex);
                response.Fail(ex, $"Error en => {nameof(ModificarPassword)}");
            }

            return response;
        }

        /// <summary>
        /// Modifica el lenguaje del usuario
        /// </summary>
        /// <param name="userResponse">usuario response</param>
        /// <returns>UsuarioResponse</returns>
        public ResponseModel ModificarLenguaje(UsuarioResponse userResponse)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuario = Mapper.Map<UsuarioResponse, Usuario>(userResponse);

                usuario = _data.ModificarLenguaje(usuario);
                userResponse = Mapper.Map<Usuario, UsuarioResponse>(usuario);

                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} guardado correctamente");
            }
            catch (NotFoundException ex)
            {
                response.NotFound(ex);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ModificarLenguaje)}", ex);
                response.Fail(ex, $"Error en => {nameof(ModificarLenguaje)}");
            }

            return response;
        }

        /// <summary>
        /// Modificar un usuario existente en base de datos por id
        /// </summary>
        /// <param name="userResponse">UsuarioResponse</param>
        /// <returns>UsuarioResponse</returns>
        public ResponseModel ModificarUsuario(UsuarioResponse userResponse)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuario = Mapper.Map<UsuarioResponse, Usuario>(userResponse);

                ///Para insertar la contraseña tiene que estar en base 64
                if (!usuario.Pw.IsEmpty() && usuario.Pw.IsBase64())
                {
                    string pwDecodeBase64 = usuario.Pw.Base64Decode();
                    string key = "KeyDecript".ReadAppConfig();
                    string pwEncode = pwDecodeBase64.Encode(key);
                    usuario.Pw = pwEncode;
                }

                Validator<Usuario, UsersValidator>(usuario);

                var newUser = _data.ModificarUsuario(usuario);
                userResponse = Mapper.Map<Usuario, UsuarioResponse>(newUser);
                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} guardado correctamente");
            }
            catch (NotFoundException ex)
            {
                response.NotFound(ex);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ModificarUsuario)}", ex);
                response.Fail(ex, $"Error en => {nameof(ModificarUsuario)}");
            }
            return response;
        }

        #endregion [Acceso a Datos de Usuarios]

        #region [Acceso a datos Informacion Complementaria]

        /// <summary>
        /// Consulta la informacion complementaria del usuario por id
        /// </summary>
        /// <param name="usuarioId">id del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>

        public ResponseModel ConsultarUsuarioInfoPorId(Guid usuarioId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var user = _dataInfoUser.ConsultarInfoPorId(usuarioId);
                if (user != null)
                {
                    var userResponse = Mapper.Map<UsuarioInfo, UsuarioInfoResponse>(user);
                    response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} consultado correctamente");
                }
                else
                {
                    response.NotFound($"No se encuentra la información por id {usuarioId}");
                }
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ConsultarUsuarioInfoPorId)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioInfoPorId)}");
            }
            return response;
        }

        /// <summary>
        /// Inserta la informacion complementaria si el usuario no la tiena
        /// </summary>
        /// <param name="userResponse">informacion complementaria del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        public ResponseModel GuardarInformacionUsuario(UsuarioInfoResponse userResponse)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var user = Mapper.Map<UsuarioInfoResponse, UsuarioInfo>(userResponse);
                user = _dataInfoUser.GuardarUsuario(user);

                userResponse = Mapper.Map<UsuarioInfo, UsuarioInfoResponse>(user);
                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} guardado correctamente");
            }
            catch (NotFoundException ex)
            {
                response.NotFound(ex);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(GuardarInformacionUsuario)}", ex);
                response.Fail(ex, $"Error en => {nameof(GuardarInformacionUsuario)}");
            }
            return response;
        }

        /// <summary>
        /// Inserta la informacion complementaria si el usuario no la tiena
        /// </summary>
        /// <param name="userResponse">informacion complementaria del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        public ResponseModel ModificarInformacionUsuario(UsuarioInfoResponse userResponse)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var user = Mapper.Map<UsuarioInfoResponse, UsuarioInfo>(userResponse);
                user = _dataInfoUser.ModificarUsuario(user);

                if (user != null)
                {
                    userResponse = Mapper.Map<UsuarioInfo, UsuarioInfoResponse>(user);
                    response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} guardado correctamente");
                }
                else 
                {
                    response.NotFound($"No existe el usuario por id {userResponse.Id}");
                }

                
            }
            catch (NotFoundException ex)
            {
                response.NotFound(ex);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ModificarInformacionUsuario)}", ex);
                response.Fail(ex, $"Error en => {nameof(ModificarInformacionUsuario)}");
            }
            return response;
        }

        #endregion [Acceso a datos Informacion Complementaria]

        #region [UsuariosEstados]

        /// <summary>
        /// Consulta el listado de estdos de los usuarios
        /// </summary>
        /// <returns>List UsuarioResponse</returns>

        public ResponseModel ConsultarEstadosUsuarios()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var estados = _dataEstados.GetModelList();
                var estadosResponse = Mapper.Map<List<UsuariosEstado>, List<DropDownItem>>(estados);
                response.SuccesCall(estadosResponse);
            }
            catch (BusinessException ex)
            {
                response.Fail(ex);
            }
            catch (Exception ex)
            {
                Logger.ErrorFatal($"{nameof(UsuarioServices)}  {nameof(ConsultarEstadosUsuarios)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarEstadosUsuarios)}");
            }
            return response;
        }

        #endregion [UsuariosEstados]

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                    if (_data != null)
                        _data.Dispose();

                    if (_dataInfoUser != null)
                        _dataInfoUser.Dispose();

                    if (_dataEstados != null)
                        _dataEstados.Dispose();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~UsuarioServices()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Clase de negocio para la entidad Usuario
    /// </summary>
    public interface IUsuarioServices : IBaseServices, IDisposable
    {
        #region [Acceso a datos Usuarios]

        /// <summary>
        /// Guardar un usuario nuevo en la base de datos
        /// </summary>
        /// <param name="userResponse">UsuarioResponse usuario nuevo a guardar en BD</param>
        /// <returns>UsuarioResponse</returns>
        ResponseModel GuardarUsuario(UsuarioResponse userResponse);

        /// <summary>
        /// Modificar un usuario existente en base de datos por id
        /// </summary>
        /// <param name="userResponse">UsuarioResponse</param>
        /// <returns>UsuarioResponse</returns>
        ResponseModel ModificarUsuario(UsuarioResponse userResponse);

        /// <summary>
        /// Consulta el usuario por id
        /// </summary>
        /// <param name="usuarioId">id de usuario</param>
        /// <returns>UsuarioResponse</returns>

        ResponseModel ConsultarUsuarioPorId(Guid usuarioId);

        /// <summary>
        /// Consulta el usuario por nombre de usuario
        /// </summary>
        /// <param name="nombreUsuario">nombre de usuario</param>
        /// <returns>UsuarioResponse</returns>

        ResponseModel ConsultarUsuarioPorNombre(string nombreUsuario);

        /// <summary>
        /// Modifica la contraseña de un usuario por id de usuario
        /// las contraseñas tienen que coincidir Password y PasswordConfirm
        /// </summary>
        /// <param name="userResponse">UsuarioResponse contraseña a modificar</param>
        /// <returns>UsuarioResponse</returns>
        ResponseModel ModificarPassword(UsuarioResponse userResponse);

        /// <summary>
        /// Modifica el lenguaje del usuario
        /// </summary>
        /// <param name="userResponse">usuario response</param>
        /// <returns>UsuarioResponse</returns>
        ResponseModel ModificarLenguaje(UsuarioResponse userResponse);

        /// <summary>
        /// Consulta el listado de usuarios de acuerdo al rol del usuario que realice la consulta
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>List UsuariosListadoResponse</returns>
        ResponseModel ConsultarUsuariosAdministrador(UsuariosFiltroRequest request);

        #endregion [Acceso a datos Usuarios]

        #region [Acceso a datos Informacion Complementaria]

        /// <summary>
        /// Consulta la informacion complementaria del usuario por id
        /// </summary>
        /// <param name="usuarioId">id del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>

        ResponseModel ConsultarUsuarioInfoPorId(Guid usuarioId);

        /// <summary>
        /// Inserta la informacion complementaria si el usuario no la tiena
        /// </summary>
        /// <param name="userResponse">informacion complementaria del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        ResponseModel GuardarInformacionUsuario(UsuarioInfoResponse userResponse);

        /// <summary>
        /// Inserta la informacion complementaria si el usuario no la tiena
        /// </summary>
        /// <param name="userResponse">informacion complementaria del usuario</param>
        /// <returns>UsuarioInfoResponse</returns>
        ResponseModel ModificarInformacionUsuario(UsuarioInfoResponse userResponse);

        #endregion [Acceso a datos Informacion Complementaria]

        #region [UsuariosEstados]

        /// <summary>
        /// Consulta el listado de estdos de los usuarios
        /// </summary>
        /// <returns>List UsuarioResponse</returns>

        ResponseModel ConsultarEstadosUsuarios();

        #endregion [UsuariosEstados]
    }
}