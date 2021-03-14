using AutoMapper;
using Netactica.Data;
using Netactica.Models;
using Netactica.Models.Exceptions;
using Netactica.Services.Response;
using Netactica.Tools;
using Netactica.Tools.StringTools;
using System;

namespace Netactica.Services
{
    /// <summary>
    /// Clase de negocio para la entidad Usuario
    /// </summary>
    public class UsuarioServices : BaseServices, IUsuarioServices, IDisposable
    {
        /// <summary>
        /// Acceso a datos a la entidad Usuario
        /// </summary>
        private readonly IUsuariosData _data;

        /// <summary>
        /// Crear constructor de negocio con el acceso de datos a Usuario
        /// </summary>
        /// <param name="data"></param>
        public UsuarioServices(IUsuariosData data)
        {
            _data = data;
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
                var userResponse = Mapper.Map<Usuario, UsuarioResponse>(user);
                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} consultado correctamente");
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
                var userResponse = Mapper.Map<Usuario, UsuarioResponse>(user);
                response.SuccesCall(userResponse, $" Usuario con nombre '{userResponse.Nombre}' consultado correctamente");
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

                Validator(usuario, new UsersValidator());

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

                Validator(usuario, new UsersValidator());
                var newUser = _data.ModificarUsuario(usuario);
                userResponse = Mapper.Map<Usuario, UsuarioResponse>(newUser);
                response.SuccesCall(userResponse, $" Usuario con id {userResponse.Id} guardado correctamente");
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

        #region [Dispose]

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
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
    }
}