using log4net.Appender;
using Netactica.Tools.StringTools;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Netactica.Tools
{
    /// <summary>
    /// Clase de conexion para Logger
    /// </summary>
    internal class CustomAdoNetAppender : AdoNetAppender
    {
        /// <summary>
        /// Comando sql
        /// </summary>
        public new string CommandText { get { return base.CommandText; } set { base.CommandText = GetCommandText(); } }

        /// <summary>
        /// Tipo de comando texto
        /// </summary>
        public new CommandType CommandType { get { return base.CommandType; } set { base.CommandType = CommandType.Text; } }

        /// <summary>
        /// Clase de conexion para Logger
        /// </summary>
        public CustomAdoNetAppender() : base()
        {
            CommandType = CommandType.Text;
            CommandText = GetCommandText();
        }

        #region [Query Command]

        /// <summary>
        /// Crea  el comando para insertar en la tabla de log LogApp
        /// </summary>
        /// <returns></returns>

        private string GetCommandText()
        {
            var queryText = new StringBuilder();
            queryText.AppendLine(@"INSERT INTO [LogApp]");
            queryText.AppendLine(@"(IdLog,");
            queryText.AppendLine(@"DateCreate,");
            queryText.AppendLine(@"ThreadLog,");
            queryText.AppendLine(@"LeveLog,");
            queryText.AppendLine(@"Logger,");
            queryText.AppendLine(@"MessagLog,");
            queryText.AppendLine(@"ExceptionLog)");
            queryText.AppendLine(@"VALUES (");
            queryText.AppendLine(@"NEWID(),");
            queryText.AppendLine(@"@DateCreate,");
            queryText.AppendLine(@"@ThreadLog,");
            queryText.AppendLine(@"@LeveLog,");
            queryText.AppendLine(@"@Logger,");
            queryText.AppendLine(@"@MessagLog,");
            queryText.AppendLine(@"@ExceptionLog)");

            return queryText.ToString();
        }

        #endregion [Query Command]

        /// <summary>
        /// Obtiene la cadena de conexion desencriptada
        /// </summary>
        /// <returns>connections tring</returns>
        private string GetConnections()
        {
            try
            {
                var connections = "DefaultDatabase".ReadConnections();
                return connections;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sobre escribe el metodo para retornar la conexion sql
        /// </summary>
        /// <param name="connectionType">typo de conexion</param>
        /// <param name="connectionString">cadena de conexion</param>
        /// <returns>IDbConnection</returns>
        protected override IDbConnection CreateConnection(Type connectionType, string connectionString)
        {
            connectionType = typeof(SqlConnection);
            connectionString = GetConnections();
            return base.CreateConnection(connectionType, connectionString);
        }
    }
}