using Dapper;
using Netactica.Models;
using Netactica.Models.Exceptions;
using System;
using System.Data;
using System.Linq;

namespace Netactica.Data
{
    /// <summary>
    /// Acceso a datos a la tabla UsuarioInfo
    /// </summary>
    public class UsuarioInfoData : Repository<UsuarioInfo>, IUsuarioInfoData, IDisposable
    {
        /// <summary>
        /// Constructor de acceso a datos de la tabla UsuarioInfo
        /// </summary>
        public UsuarioInfoData() : base()
        {
        }

        /// <summary>
        /// Obtiene la informacion complementaria del usuario por id de usuario
        /// </summary>
        /// <param name="usuarioId">usuario id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioInfo</returns>
        public UsuarioInfo ConsultarInfoPorId(Guid usuarioId, IDbTransaction transaction = null)
        {
            try
            {
                var query = DataBase.Query<UsuarioInfo, TipoIdentificacion, UsuarioInfo>(sql: "NetacticaDB_SP_UsuarioInfoPorId",
                    param: new { UsuarioId = usuarioId }, transaction: transaction, splitOn: "split", map: (ui, ti) => { ui.TipoIdentificacion = ti; return ui; }, commandType: CommandType.StoredProcedure).ToList();

                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta la informacion complementaria del usuario
        /// </summary>
        /// <param name="usuario">usuario info complementaria</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioInfo</returns>
        public UsuarioInfo GuardarUsuario(UsuarioInfo usuario, IDbTransaction transaction = null)
        {
            try
            {
                if (ExisteUsuarioInfo(usuario, transaction))
                    throw new BusinessException($"Ya existe la información complementaria del usuario con este id '{usuario.UsuarioId}' verifique !!");

                usuario.FechaCreacion = DateTime.Now;
                usuario.FechaModificacion = null;
                usuario.UsuarioModifica = null;

                var id = InsertGetKey<Guid>(usuario, transaction);

                usuario.UsuarioId = id;
                return usuario;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica la informacion complementaria del usuario por id de usuario
        /// </summary>
        /// <param name="usuario">usuario info complementaria</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioInfo</returns>
        public UsuarioInfo ModificarUsuario(UsuarioInfo usuario, IDbTransaction transaction = null)
        {
            try
            {
                if (!ExisteUsuarioInfo(usuario, transaction))
                    throw new BusinessException($"No existe la información complementaria del usuario con este id '{usuario.UsuarioId}' verifique !!");

                var oldUser = GetFindById(usuario.UsuarioId, transaction);

                if (oldUser == null)
                    throw new NotFoundException($"No existe la información del usuario por id {usuario.UsuarioId}");

                oldUser.Apellidos = usuario.Apellidos;
                oldUser.CorreoAlternativo = usuario.CorreoAlternativo;
                oldUser.Direccion = usuario.Direccion;
                oldUser.Documento = usuario.Documento;
                oldUser.FechaModificacion = DateTime.Now;
                oldUser.UsuarioModifica = usuario.UsuarioModifica;
                oldUser.FechaNacimiento = usuario.FechaNacimiento;
                oldUser.Nombres = usuario.Nombres;
                oldUser.Telefono = usuario.Telefono;
                oldUser.TipoIdentificacionId = usuario.TipoIdentificacionId;

                Update(oldUser, transaction);

                usuario = ConsultarInfoPorId(usuario.UsuarioId, transaction);

                return usuario;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si ya existe la informacion complementaria del usuario creada
        /// </summary>
        /// <param name="usuario">usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>true si existe , false si no existe</returns>
        private bool ExisteUsuarioInfo(UsuarioInfo usuario, IDbTransaction transaction = null)
        {
            try
            {
                var count = Count("WHERE UsuarioId = @id", parameters: new { id = usuario.UsuarioId }, transaction: transaction);
                return count > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla UsuarioInfo
    /// </summary>
    public interface IUsuarioInfoData : IRepository<UsuarioInfo>, IDisposable
    {
        /// <summary>
        /// Obtiene la informacion complementaria del usuario por id de usuario
        /// </summary>
        /// <param name="usuarioId">usuario id</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioInfo</returns>
        UsuarioInfo ConsultarInfoPorId(Guid usuarioId, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta la informacion complementaria del usuario
        /// </summary>
        /// <param name="usuario">usuario info complementaria</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioInfo</returns>
        UsuarioInfo GuardarUsuario(UsuarioInfo usuario, IDbTransaction transaction = null);

        /// <summary>
        /// Modifica la informacion complementaria del usuario por id de usuario
        /// </summary>
        /// <param name="usuario">usuario info complementaria</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UsuarioInfo</returns>
        UsuarioInfo ModificarUsuario(UsuarioInfo usuario, IDbTransaction transaction = null);
    }
}