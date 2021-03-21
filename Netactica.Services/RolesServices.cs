using AutoMapper;
using Netactica.Data;
using Netactica.Models;
using Netactica.Models.Exceptions;
using Netactica.Services.Request;
using Netactica.Services.Response;
using Netactica.Tools;
using System;
using System.Collections.Generic;

namespace Netactica.Services
{
    /// <summary>
    /// Clase de servicio para el acceso a datos a Roles
    /// </summary>
    public class RolesServices : BaseServices, IRolesServices, IDisposable
    {
        #region [Propiedades]

        /// <summary>
        /// Acceso a datos a roles
        /// </summary>
        private readonly IRolesData _data;

        /// <summary>
        /// Acceso a datos usuarios roles
        /// </summary>
        private readonly IUsuarioRolesData _dataRolesUsers;

        #endregion [Propiedades]

        #region [Constructor]

        public RolesServices(IRolesData data, IUsuarioRolesData dataRolesUsers)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _dataRolesUsers = dataRolesUsers ?? throw new ArgumentNullException(nameof(dataRolesUsers));
        }

        #endregion [Constructor]

        #region [Roles]

        /// <summary>
        /// Identifica si el id es un rol de super administrador
        /// </summary>
        /// <param name="rolId"></param>
        /// <returns></returns>
        public ResponseModel EsRolAdministrador(Guid rolId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var isSuperAdmon = _data.IsRolAdmon(rolId);
                response.SuccesCall(isSuperAdmon, "Consulta cargada correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(EsRolAdministrador)}", ex);
                response.Fail(ex, $"Error en => {nameof(EsRolAdministrador)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta un rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>Roles</returns>
        public ResponseModel ConsultarRolPorId(Guid rolId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var rol = _data.ConsultarRolPorId(rolId);
                if (rol != null)
                {
                    var rolResponse = Mapper.Map<Roles, RolesResponse>(rol);
                    response.SuccesCall(rolResponse, $"Rol con id {rol.RolId} consultado correctamente");
                }
                else
                {
                    response.NotFound($"No existe el rol con id {rolId}");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarRolPorId)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarRolPorId)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta el listado de roles segun el filtro aplicado
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns>List Roles</returns>
        public ResponseModel ConsultarRoles(RolesFiltroRequest filtroRequest)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var filtro = Mapper.Map<RolesFiltroRequest, RolesFiltro>(filtroRequest);
                var query = _data.ConsultarRoles(filtro);
                var queryResponse = Mapper.Map<List<Roles>, List<RolesResponse>>(query);
                response.SuccesCall(queryResponse, $"Consulta cargada correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarRoles)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarRoles)}");
            }
            return response;
        }

        /// <summary>
        /// Inserta un nuevo rol en base de datos
        /// </summary>
        /// <param name="roles">rol</param>
        /// <returns>Roles</returns>
        public ResponseModel GuardarRol(RolesResponse request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var rol = Mapper.Map<RolesResponse, Roles>(request);
                Validator<Roles, RolesValidator>(rol);

                rol = _data.GuardarRol(rol);

                var rolResponse = Mapper.Map<Roles, RolesResponse>(rol);

                response.SuccesCall(rolResponse, $"Rol con id {rol.RolId} creado correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(GuardarRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(GuardarRol)}");
            }
            return response;
        }

        /// <summary>
        /// Modifica un nuevo rol por id
        /// </summary>
        /// <param name="roles">rol</param>
        /// <returns>Roles</returns>
        public ResponseModel ModificarRol(RolesResponse request)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var rol = Mapper.Map<RolesResponse, Roles>(request);
                Validator<Roles, RolesValidator>(rol);

                rol = _data.ModificarRol(rol);

                var rolResponse = Mapper.Map<Roles, RolesResponse>(rol);

                response.SuccesCall(rolResponse, $"Rol con id {rol.RolId} guardado correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ModificarRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(ModificarRol)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta los roles por Tercero Id
        /// </summary>
        /// <param name="TerceroId">id del tercero</param>
        /// <returns>List Roles</returns>
        public ResponseModel ConsultarRolesPorTercero(Guid terceroId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var roles = _data.ConsultarRolesPorTercero(terceroId);
                var responseRoles = Mapper.Map<List<Roles>, List<RolesResponse>>(roles);
                response.SuccesCall(responseRoles, "Consulta cargada correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarRolesPorTercero)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarRolesPorTercero)}");
            }
            return response;
        }

        #endregion [Roles]

        #region [Usuario Rol]

        // <summary>
        /// Consulta el usuario rol por id
        /// </summary>
        /// <param name="usuarioRolId">id usuairo rol</param>
        /// <returns>ResponseModel UsuariosRolesResponse</returns>
        public ResponseModel ConsultarUsuarioRolPorId(Guid usuarioRolId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuarioRol = _dataRolesUsers.ConsultarUsuarioRolPorId(usuarioRolId);

                if (usuarioRol != null)
                {
                    var usuarioResponse = Mapper.Map<UsuarioRoles, UsuarioRolesResponse>(usuarioRol);
                    response.SuccesCall(usuarioResponse, $"Usuario rol con id {usuarioRolId} consultado correctamente");
                }
                else
                {
                    response.Fail($"Usuario rol con id {usuarioRolId} no se encuentra en base de datos");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarUsuarioRolPorId)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioRolPorId)}");
            }
            return response;
        }

        /// <summary>
        /// Guarda un nuevo usuario rol en la base de datos
        /// </summary>
        /// <param name="usuarioRol">UsuariosRolesResponse</param>
        /// <returns>UsuariosRolesResponse</returns>
        public ResponseModel GuardarUsuarioRol(UsuarioRolesResponse usuarioRol)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var role = Mapper.Map<UsuarioRolesResponse, UsuarioRoles>(usuarioRol);

                Validator<UsuarioRoles, UsuariosRolesValidator>(role);

                role = _dataRolesUsers.GuardarUsuarioRol(role);

                var roleResponse = Mapper.Map<UsuarioRoles, UsuarioRolesResponse>(role);

                response.SuccesCall(roleResponse, $"Usuario rol creado correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(GuardarUsuarioRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(GuardarUsuarioRol)}");
            }
            return response;
        }

        /// <summary>
        /// Modifica un usuario rol por id en la base de datos
        /// </summary>
        /// <param name="usuarioRol">UsuariosRolesResponse</param>
        /// <returns>UsuariosRolesResponse</returns>
        public ResponseModel ModificarUsuarioRol(UsuarioRolesResponse usuarioRol)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var role = Mapper.Map<UsuarioRolesResponse, UsuarioRoles>(usuarioRol);

                Validator<UsuarioRoles, UsuariosRolesValidator>(role);

                role = _dataRolesUsers.ModificarUsuarioRol(role);

                var roleResponse = Mapper.Map<UsuarioRoles, UsuarioRolesResponse>(role);

                response.SuccesCall(roleResponse, $"Usuario rol guardado correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ModificarUsuarioRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(ModificarUsuarioRol)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta el listado de roles por rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>ResponseModel List UsuarioRolesResponse</returns>
        public ResponseModel ConsultarUsuarioRolPorRol(Guid rolId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuariosRoles = _dataRolesUsers.ConsultarUsuarioRolPorRol(rolId);
                var usuariosResponse = Mapper.Map<List<UsuarioRoles>, List<UsuarioRolesResponse>>(usuariosRoles);
                response.SuccesCall(usuariosResponse, "Consulta cargada correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarUsuarioRolPorRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioRolPorRol)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta el listado de roles por usuario id
        /// </summary>
        /// <param name="usuarioId">rol id</param>
        /// <returns>ResponseModel List UsuarioRolesResponse</returns>
        public ResponseModel ConsultarUsuarioRolPorUsuario(Guid usuarioId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuariosRoles = _dataRolesUsers.ConsultarUsuarioRolPorUsuario(usuarioId);
                var usuariosResponse = Mapper.Map<List<UsuarioRoles>, List<UsuarioRolesResponse>>(usuariosRoles);
                response.SuccesCall(usuariosResponse, "Consulta cargada correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarUsuarioRolPorRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioRolPorRol)}");
            }
            return response;
        }

        /// <summary>
        /// Consulta los roles de los usuario por tercero id
        /// </summary>
        /// <param name="terceroId">tercero id</param>
        /// <returns></returns>
        public ResponseModel ConsultarUsuarioRolPorTercero(Guid terceroId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var usuariosRoles = _dataRolesUsers.ConsultarUsuarioRolPorTercero(terceroId);
                var usuariosResponse = Mapper.Map<List<UsuarioRoles>, List<UsuarioRolesResponse>>(usuariosRoles);
                response.SuccesCall(usuariosResponse, "Consulta cargada correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(ConsultarUsuarioRolPorRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(ConsultarUsuarioRolPorRol)}");
            }
            return response;
        }

        #endregion [Usuario Rol]

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

                    if (_dataRolesUsers != null)
                        _dataRolesUsers.Dispose();
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~RolesServices()
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
    /// Clase de servicio para el acceso a datos a Roles
    /// </summary>
    public interface IRolesServices : IBaseServices, IDisposable
    {
        #region [Roles]

        /// <summary>
        /// Inserta un nuevo rol en base de datos
        /// </summary>
        /// <param name="roles">rol</param>
        /// <returns>Roles</returns>
        ResponseModel GuardarRol(RolesResponse request);

        /// <summary>
        /// Modifica un nuevo rol por id
        /// </summary>
        /// <param name="roles">rol</param>
        /// <returns>Roles</returns>
        ResponseModel ModificarRol(RolesResponse request);

        /// <summary>
        /// Consulta los roles por Tercero Id
        /// </summary>
        /// <param name="TerceroId">id del tercero</param>
        /// <returns>List Roles</returns>
        ResponseModel ConsultarRolesPorTercero(Guid terceroId);

        /// <summary>
        /// Identifica si el rol es rol administrador
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>Roles</returns>
        ResponseModel EsRolAdministrador(Guid rolId);

        /// <summary>
        /// Consulta el listado de roles segun el filtro aplicado
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns>List Roles</returns>
        ResponseModel ConsultarRoles(RolesFiltroRequest filtroRequest);

        /// <summary>
        /// Consulta un rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>Roles</returns>
        ResponseModel ConsultarRolPorId(Guid rolId);

        #endregion [Roles]

        #region [Usuario Rol]

        /// <summary>
        /// Consulta el usuario rol por id
        /// </summary>
        /// <param name="usuarioRolId">id usuairo rol</param>
        /// <returns>ResponseModel UsuariosRolesResponse</returns>
        ResponseModel ConsultarUsuarioRolPorId(Guid usuarioRolId);

        /// <summary>
        /// Guarda un nuevo usuario rol en la base de datos
        /// </summary>
        /// <param name="usuarioRol">UsuariosRolesResponse</param>
        /// <returns>UsuariosRolesResponse</returns>
        ResponseModel GuardarUsuarioRol(UsuarioRolesResponse usuarioRol);

        /// <summary>
        /// Modifica un usuario rol por id en la base de datos
        /// </summary>
        /// <param name="usuarioRol">UsuariosRolesResponse</param>
        /// <returns>UsuariosRolesResponse</returns>
        ResponseModel ModificarUsuarioRol(UsuarioRolesResponse usuarioRol);

        /// <summary>
        /// Consulta el listado de roles por rol id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>ResponseModel List UsuarioRolesResponse</returns>
        ResponseModel ConsultarUsuarioRolPorRol(Guid rolId);

        /// <summary>
        /// Consulta los roles de los usuario por tercero id
        /// </summary>
        /// <param name="terceroId">tercero id</param>
        /// <returns></returns>
        ResponseModel ConsultarUsuarioRolPorTercero(Guid terceroId);

        /// <summary>
        /// Consulta el listado de roles por usuario id
        /// </summary>
        /// <param name="usuarioId">rol id</param>
        /// <returns>ResponseModel List UsuarioRolesResponse</returns>
        ResponseModel ConsultarUsuarioRolPorUsuario(Guid usuarioId);

        #endregion [Usuario Rol]
    }
}