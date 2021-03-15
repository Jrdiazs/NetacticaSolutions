using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Netactica.Data
{
    /// <summary>
    /// Repositorio para una entidad
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class Repository<TModel> : DataConnections, IRepository<TModel>, IDataConnections, IDisposable
    {
        #region [Constructor]

        /// <summary>
        /// Conexion a base de datos por default
        /// </summary>
        public Repository() : base()
        {
        }

        public Repository(IDbConnection connection)
        {
            DataBase = connection;
        }

        #endregion [Constructor]

        #region [Metodos]

        /// <summary>
        /// Ejecuta un escalar y retorna el objeto
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="parameters">parametros</param>
        /// <param name="transaction">transaccion sql</param>
        /// <param name="typeCommand">tipo de comando</param>
        /// <returns></returns>
        public object ExecuteEscalar(string sql, object parameters, IDbTransaction transaction = null, CommandType typeCommand = CommandType.Text)
        {
            try
            {
                return DataBase.ExecuteScalar(sql, param: parameters, transaction: transaction, commandType: typeCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ejecuta un query a la base de datos tipo delete, update, insert, retorna el numero de filas afectadas
        /// </summary>
        /// <param name="sql">sql query</param>
        /// <param name="parameters">parametros</param>
        /// <param name="transaction">transacción sql</param>
        /// <param name="typeCommand">tipo de comando de base datos text o store procedure</param>
        /// <returns></returns>
        public int ExecuteQuery(string sql, object parameters, IDbTransaction transaction = null, CommandType typeCommand = CommandType.Text)
        {
            try
            {
                return DataBase.Execute(sql: sql, param: parameters, transaction: transaction, commandType: typeCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un objeto  nuevo a la base de datos y retorna el id segun el tipo de dato seleccionado en Tkey
        /// </summary>
        /// <typeparam name="Tkey">tipo de dato de la llave</typeparam>
        /// <param name="model">modelo </param>
        /// <param name="transaction">transacción</param>
        /// <returns>id del modelo</returns>
        public Tkey InsertGetKey<Tkey>(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                var key = DataBase.Insert<Tkey, TModel>(model, transaction: transaction);
                return key;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(object id, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.Delete<TModel>(id, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un objeto en base de datos y retorna el id generado
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transacción</param>
        /// <returns>int?</returns>
        public int? Insert(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                var rowsAfected = DataBase.Insert(model, transaction: transaction);
                return rowsAfected;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene un objeto de la base de datos por id
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public TModel GetFindById(object id, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.Get<TModel>(id, transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de base de datos de una entidad
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Count(IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.RecordCount<TModel>(whereConditions: null, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de base de datos de una entidad segun el filtro aplicado
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Count(string whereConditions, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.RecordCount<TModel>(whereConditions: whereConditions, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de base de datos de una entidad segun el filtro aplicado
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="parameters">parametros</param>
        /// <param name="whereConditions">where sql</param>
        /// <returns></returns>
        public int Count(string whereConditions, object parameters, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.RecordCount<TModel>(conditions: whereConditions, parameters: parameters, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza una entidad por id en la base de datos
        /// </summary>
        /// <param name="model">modelo a actualiza en la base de datos</param>
        /// <param name="transaction">transacción sql</param>
        /// <returns>numero de filtas afectadas</returns>
        public int Update(TModel model, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.Update(model, transaction: transaction);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los registros de una entidad
        /// </summary>
        /// <returns></returns>
        public List<TModel> GetModelList()
        {
            try
            {
                return DataBase.GetList<TModel>().ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene los resultados de una entidad segun el filtro
        /// </summary>
        /// <param name="whereConditions">filtro sql</param>
        /// <param name="transaction">transacción</param>
        /// <returns></returns>
        public List<TModel> GetModelList(string whereConditions, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.GetList<TModel>(whereConditions: whereConditions, transaction: transaction).ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene los resultados de una entidad segun el filtro y los parametros seleccionados
        /// </summary>
        /// <param name="whereConditions">filtro sql</param>
        /// <param name="transaction">transacción</param>
        /// <returns></returns>
        public List<TModel> GetModelList(object parameters, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.GetList<TModel>(whereConditions: parameters, transaction: transaction).ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene los resultados de una entidad segun el filtro sql y los parametros seleccionados
        /// </summary>
        /// <param name="where">sql where</param>
        /// <param name="parameters">parameters</param>
        /// <param name="transaction">transacción</param>
        /// <returns></returns>
        public List<TModel> GetModelList(string where, object parameters, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.GetList<TModel>(conditions: where, parameters: parameters, transaction: transaction).ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene una lista paginada de la entidad
        /// </summary>
        /// <param name="pageNumber">numero de pagina a obtener</param>
        /// <param name="rowsPerPage">filas por pagina</param>
        /// <param name="whereConditions">filtro sql</param>
        /// <param name="orderBy">ordenamiento sql</param>
        /// <param name="transaction">transacción sql</param>
        /// <returns></returns>
        public List<TModel> GetPageModelList(int pageNumber, int rowsPerPage, string whereConditions, string orderBy, IDbTransaction transaction = null)
        {
            try
            {
                return DataBase.GetListPaged<TModel>(pageNumber: pageNumber, rowsPerPage: rowsPerPage, conditions: whereConditions, orderby: orderBy, transaction: transaction).ToList() ?? new List<TModel>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el nombre de la tabla del repositorio actual
        /// </summary>
        /// <returns>TableName</returns>
        public string TableName()
        {
            try
            {
                var tableAttribute = typeof(TModel).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
                if (tableAttribute != null)
                    return tableAttribute.Name;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Realiza un bulk insert a la tabla del repositorio actual
        /// </summary>
        /// <param name="table">tabla actual</param>
        /// <param name="transaction">transacción sql server</param>
        /// <param name="option">sql copy options</param>
        /// <param name="batchSize">numero de registros por transacción</param>
        public void BulkInsert(DataTable table, IDbTransaction transaction, string tableName = null, SqlBulkCopyOptions? option = null, int? batchSize = null)
        {
            try
            {
                using (var bulkInsert = new SqlBulkCopy((SqlConnection)DataBase, option.HasValue ? option.Value : SqlBulkCopyOptions.Default, (SqlTransaction)transaction))
                {
                    #region [Mapping Columns]

                    foreach (DataColumn column in table.Columns)
                    {
                        bulkInsert.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                    }

                    #endregion [Mapping Columns]

                    if (batchSize.HasValue && batchSize > 0)
                        bulkInsert.BatchSize = batchSize.Value;

                    bulkInsert.DestinationTableName = tableName ?? TableName();
                    bulkInsert.WriteToServer(table);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion [Metodos]
    }

    #region [IConnectRepository]

    public interface IRepository<TModel> : IDataConnections, IDisposable
    {
        int Delete(object id, IDbTransaction transaction = null);

        /// <summary>
        /// Ejecuta un escalar y retorna el objeto
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="parameters">parametros</param>
        /// <param name="transaction">transaccion sql</param>
        /// <param name="typeCommand">tipo de comando</param>
        /// <returns></returns>
        object ExecuteEscalar(string sql, object parameters, IDbTransaction transaction = null, CommandType typeCommand = CommandType.Text);

        /// <summary>
        /// Ejecuta un query a la base de datos tipo delete, update, insert, retorna el numero de filas afectadas
        /// </summary>
        /// <param name="sql">sql query</param>
        /// <param name="parameters">parametros</param>
        /// <param name="transaction">transacción sql</param>
        /// <param name="typeCommand">tipo de comando de base datos text o store procedure</param>
        /// <returns></returns>
        int ExecuteQuery(string sql, object parameters, IDbTransaction transaction = null, CommandType typeCommand = CommandType.Text);

        /// <summary>
        /// Obtiene todos los registros de base de datos de una entidad
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Count(IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene todos los registros de base de datos de una entidad segun el filtro aplicado
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        int Count(string whereConditions, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene todos los registros de base de datos de una entidad segun el filtro aplicado
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="parameters">parametros</param>
        /// <param name="whereConditions">where sql</param>
        /// <returns></returns>
        int Count(string whereConditions, object parameters, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene un objeto de la base de datos por id
        /// </summary>
        /// <param name="id">id del objeto</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        TModel GetFindById(object id, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene todos los registros de una entidad
        /// </summary>
        /// <returns></returns>
        List<TModel> GetModelList();

        /// <summary>
        /// Obtiene los resultados de una entidad segun el filtro
        /// </summary>
        /// <param name="whereConditions">filtro sql</param>
        /// <param name="transaction">transacción</param>
        /// <returns></returns>
        List<TModel> GetModelList(string whereConditions, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene los resultados de una entidad segun el filtro y los parametros seleccionados
        /// </summary>
        /// <param name="transaction">transacción</param>
        /// <returns></returns>
        List<TModel> GetModelList(object parameters, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene los resultados de una entidad segun el filtro sql y los parametros seleccionados
        /// </summary>
        /// <param name="where">sql where</param>
        /// <param name="parameters">parameters</param>
        /// <param name="transaction">transacción</param>
        /// <returns></returns>
        List<TModel> GetModelList(string where, object parameters, IDbTransaction transaction = null);

        /// <summary>
        /// Obtiene una lista paginada de la entidad
        /// </summary>
        /// <param name="pageNumber">numero de pagina a obtener</param>
        /// <param name="rowsPerPage">filas por pagina</param>
        /// <param name="whereConditions">filtro sql</param>
        /// <param name="orderBy">ordenamiento sql</param>
        /// <param name="transaction">transacción sql</param>
        /// <returns></returns>
        List<TModel> GetPageModelList(int pageNumber, int rowsPerPage, string whereConditions, string orderBy, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta un objeto en base de datos y retorna el id generado
        /// </summary>
        /// <param name="model">modelo</param>
        /// <param name="transaction">transacción</param>
        /// <returns>int?</returns>
        int? Insert(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Inserta un objeto  nuevo a la base de datos y retorna el id segun el tipo de dato seleccionado en Tkey
        /// </summary>
        /// <typeparam name="Tkey">tipo de dato de la llave</typeparam>
        /// <param name="model">modelo </param>
        /// <param name="transaction">transacción</param>
        /// <returns>id del modelo</returns>
        Tkey InsertGetKey<Tkey>(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Actualiza una entidad por id en la base de datos
        /// </summary>
        /// <param name="model">modelo a actualiza en la base de datos</param>
        /// <param name="transaction">transacción sql</param>
        /// <returns>numero de filtas afectadas</returns>
        int Update(TModel model, IDbTransaction transaction = null);

        /// <summary>
        /// Realiza un bulk insert a la tabla del repositorio actual
        /// </summary>
        /// <param name="table">tabla actual</param>
        /// <param name="transaction">transacción sql server</param>
        /// <param name="option">sql copy options</param>
        /// <param name="batchSize">numero de registros por transacción</param>
        void BulkInsert(DataTable table, IDbTransaction transaction, string tableName = null, SqlBulkCopyOptions? option = null, int? batchSize = null);

        /// <summary>
        /// Obtiene el nombre de la tabla del repositorio actual
        /// </summary>
        /// <returns>TableName</returns>
        string TableName();
    }

    #endregion [IConnectRepository]
}