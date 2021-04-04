using Netactica.Models;
using Netactica.Models.Exceptions;
using Netactica.Tools.StringTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Netactica.Data
{
    /// <summary>
    /// Clase de parametros de aplicacion
    /// </summary>
    public class ParametrosData : Repository<Parametros>, IParametrosData, IDisposable
    {
        public ParametrosData() : base()
        {
        }

        /// <summary>
        /// Consulta el parametro por llave
        /// </summary>
        /// <param name="keyName">nombre de la llave del parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        public Parametros ConsultarParametroPorLlave(string keyName, IDbTransaction transaction = null)
        {
            try
            {
                var query = GetModelList("WHERE ParametroLlave = @llave", new { llave = keyName }, transaction);
                return query.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un listado de parametros por llave segun lo que contenta el parametro keyName
        /// </summary>
        /// <param name="keyName">llave del parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>List Parametros </returns>
        public List<Parametros> ConsultarParametros(string keyName, IDbTransaction transaction = null)
        {
            try
            {
                keyName = keyName.LikeSql();

                var query = GetModelList("WHERE ParametroLlave LIKE @llave", new { llave = keyName }, transaction);
                return query ?? new List<Parametros>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo parametro en la base de datos, verifica que no exista el parametro por llave
        /// </summary>
        /// <param name="parametros">parametro de app</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        public Parametros GuardarParametro(Parametros parametros, IDbTransaction transaction = null)
        {
            try
            {
                parametros.FechaCreacion = DateTime.Now;
                parametros.UsuarioModifica = null;
                parametros.FechaModificacion = null;

                var count = Count("WHERE ParametroLlave =@llave", new { llave = parametros.ParametroLlave }, transaction);

                if (count > 0)
                    throw new BusinessException($"Ya existe un parametro con esta llave '{parametros.ParametroLlave}' verifique !!");

                var id = InsertGetKey<Guid>(parametros, transaction);
                parametros.ParametroId = id;

                return parametros;
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
        /// Modifica un parametro existente en la base de datos por id
        /// </summary>
        /// <param name="parametros">parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        public Parametros ModificarParametroParametro(Parametros parametros, IDbTransaction transaction = null)
        {
            try
            {
                parametros.FechaModificacion = DateTime.Now;

                var oldParameter = GetFindById(parametros.ParametroId, transaction);
                if (oldParameter == null)
                    throw new NotFoundException($"No existe el parametro por id {parametros.ParametroId}");

                var count = Count("WHERE ParametroLlave =@llave AND ParametroId <> @id", new { llave = parametros.ParametroLlave, id = parametros.ParametroId }, transaction);

                if (count > 0)
                    throw new BusinessException($"Ya existe un parametro con esta llave '{parametros.ParametroLlave}' verifique !!");

                oldParameter.FechaModificacion = parametros.FechaModificacion;
                oldParameter.ParametroDescripcion = parametros.ParametroDescripcion;
                oldParameter.ValorBingInt = parametros.ValorBingInt;
                oldParameter.ValorBoleano = parametros.ValorBoleano;
                oldParameter.ValorDateTime = parametros.ValorDateTime;
                oldParameter.ValorEntero = parametros.ValorEntero;
                oldParameter.ValorGuid = parametros.ValorGuid;
                oldParameter.ValorString = parametros.ValorString;
                oldParameter.UsuarioModifica = parametros.UsuarioModifica;

                Update(oldParameter, transaction);

                return oldParameter;
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
        /// Consulta el parametro por id
        /// </summary>
        /// <param name="keyName">id del parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        public Parametros ConsultarParametroPorId(Guid id, IDbTransaction transaction = null)
        {
            try
            {
                var parameter = GetFindById(id, transaction);
                return parameter;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Clase de parametros de aplicacion
    /// </summary>
    public interface IParametrosData : IRepository<Parametros>, IDisposable
    {
        /// <summary>
        /// Inserta un nuevo parametro en la base de datos, verifica que no exista el parametro por llave
        /// </summary>
        /// <param name="parametros">parametro de app</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        Parametros GuardarParametro(Parametros parametros, IDbTransaction transaction = null);

        /// <summary>
        /// Modifica un parametro existente en la base de datos por id
        /// </summary>
        /// <param name="parametros">parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>

        Parametros ModificarParametroParametro(Parametros parametros, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el parametro por llave
        /// </summary>
        /// <param name="keyName">nombre de la llave del parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        Parametros ConsultarParametroPorLlave(string keyName, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta el parametro por id
        /// </summary>
        /// <param name="keyName">id del parametro</param>
        /// <param name="transaction">transaction sql</param>
        /// <returns>Parametros</returns>
        Parametros ConsultarParametroPorId(Guid id, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un listado de parametros por llave segun lo que contenta el parametro keyName
        /// </summary>
        /// <param name="keyName">llave del parametro</param>
        /// <param name="transaction">ransaction sql</param>
        /// <returns>List Parametros </returns>
        List<Parametros> ConsultarParametros(string keyName, IDbTransaction transaction = null);
    }
}