using AutoMapper;
using Netactica.Data;
using Netactica.Models;
using Netactica.Models.Exceptions;
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
        /// <summary>
        /// Acceso a datos a roles
        /// </summary>
        private readonly IRolesData _data;

        /// <summary>
        /// Constructor acceso a datos Roles
        /// </summary>
        /// <param name="data"></param>
        public RolesServices(IRolesData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
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
                if (rol == null)
                {
                    var rolResponse = Mapper.Map<Roles, RolesResponse>(rol);
                    response.SuccesCall(rolResponse, $"Rol con id {rol.RolId} creado correctamente");
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
                Logger.ErrorFatal($"{nameof(RolesServices)}  {nameof(GuardarRol)}", ex);
                response.Fail(ex, $"Error en => {nameof(GuardarRol)}");
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
        /// Consulta un rol por id
        /// </summary>
        /// <param name="rolId">rol id</param>
        /// <returns>Roles</returns>
        ResponseModel ConsultarRolPorId(Guid rolId);
    }
}