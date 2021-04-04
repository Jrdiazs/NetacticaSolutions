using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;

namespace Netactica.Tools.Map
{
    public static class MappingTo
    {
        /// <summary>
        /// Determina si objeto es nulo o no
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull<T>(this T obj)
        {
            try
            {
                if (obj == null) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene datos de una lista segun un filtro dinamico
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">listado</param>
        /// <param name="filter">filtro</param>
        /// <param name="parameters">parametros</param>
        /// <returns></returns>
        public static List<T> DynamicFilter<T>(this List<T> values, string filter, params object[] parameters)
        {
            try
            {
                if (null == values) return new List<T>();
                return values.Where(filter, parameters).ToList() ?? new List<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determina si una lista tiene por lo menos un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool HasRecords<T>(this IEnumerable<T> obj)
        {
            try
            {
                if (obj.IsNull()) return false;
                return obj.Any();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte una lista generica a un datatable
        /// </summary>
        /// <typeparam name="T">Tipo de dato de la lista</typeparam>
        /// <param name="data">data</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToDataTable<T>(this List<T> data)
        {
            try
            {
                var table = new DataTable();
                using (var reader = ObjectReader.Create(data))
                {
                    table.Load(reader);
                }
                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un listado generico a un datatable con ordenamiento de columnas
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">lista generica</param>
        /// <param name="parameters">listado de parametros que definen el ordenamiento de posicion de columnas
        /// del datatable</param>
        /// <returns>DataTable</returns>
        public static DataTable ListToDataTable<T>(this List<T> data, params string[] parameters)
        {
            try
            {
                var table = new DataTable();

                if (data.HasRecords())
                {
                    using (var reader = ObjectReader.Create(data))
                    {
                        table.Load(reader);
                    }
                }

                if (table.Rows.Count > 0)
                {
                    foreach (var param in parameters.Select((value, index) => new { Index = index, Value = value }))
                    {
                        if (table.Columns.Cast<DataColumn>().Select(x => x.ColumnName).Contains(param.Value))
                            table.Columns[param.Value].SetOrdinal(param.Index);
                    }
                }

                return table;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Clona los valores de una lista generica a otra
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listValues">Lista de valores</param>
        /// <returns></returns>
        public static List<T> Clone<T>(this List<T> listValues) where T : ICloneable
        {
            try
            {
                if (!listValues.HasRecords()) return new List<T> { };
                return listValues.Select(item => (T)item.Clone()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica si un objeto es diferente del otro del mismo tipo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="to"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        public static bool EqualsProperties<T>(this T self, T to, params string[] ignore) where T : class
        {
            try
            {
                if (self != null && to != null)
                {
                    var type = typeof(T);
                    var ignoreList = new List<string>(ignore);
                    foreach (var pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (!ignoreList.Contains(pi.Name))
                        {
                            var selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                            var toValue = type.GetProperty(pi.Name).GetValue(to, null);

                            if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                return self == to;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Clona los valores de un objeto a otro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Clone<T>(this T value) where T : ICloneable
        {
            try
            {
                return (T)value.Clone();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un datatable a lista
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable">DataTable</param>
        /// <param name="excludeProperties">propiedades a excluir</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(this DataTable dataTable, params string[] excludeProperties)
        {
            try
            {
                if (null == dataTable) return new List<T>();

                var columnNames = dataTable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead && x.CanWrite && !excludeProperties.Contains(x.Name));

                return dataTable.AsEnumerable().Select(row =>
                {
                    var objT = Activator.CreateInstance<T>();

                    foreach (var pro in properties)
                    {
                        if (columnNames.Contains(pro.Name))
                            if (!Convert.IsDBNull(row[pro.Name]))
                                pro.SetValue(objT, row[pro.Name]);
                    }

                    return objT;
                }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Mapea los datos de un datareader a una lista generica
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">reader</param>
        /// <param name="excludeColumns">columnas a excluir</param>
        /// <returns>List<T> </returns>
        public static List<T> MapToList<T>(this DbDataReader reader, params string[] excludeColumns) where T : class, new()
        {
            try
            {
                var data = new List<T>();
                var entity = typeof(T);

                var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.CanRead && x.CanWrite && !excludeColumns.Contains(x.Name)).ToList();
                DataTable table = reader.GetSchemaTable();

                if (table != null && table.Rows.Count > 0)
                {
                    List<string> columnNames = table != null ? table.AsEnumerable().Select(x => x.Field<string>("ColumnName").ToUpper()).ToList() : new List<string>();

                    if (columnNames != null && columnNames.Count > 0)
                        props = props.Where(x => columnNames.Contains(x.Name.ToUpper())).ToList();
                }

                if (reader != null && !reader.IsClosed)
                {
                    while (reader.Read())
                    {
                        var item = Activator.CreateInstance<T>();

                        foreach (var property in props)
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                            {
                                Type convertTo = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                                property.SetValue(item, Convert.ChangeType(reader[property.Name], convertTo), null);
                            }
                            else if (property.PropertyType == typeof(string))
                            {
                                property.SetValue(item, string.Empty);
                            }
                        }

                        data.Add(item);
                    }
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <Summary>
        /// Map data from DataReader to an object
        /// </Summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="reader">Data Reader</param>
        /// <returns>Object having data from Data Reader</returns>
        public static T MapToSingle<T>(this DbDataReader reader) where T : new()
        {
            try
            {
                var value = new T();
                var entity = typeof(T);
                var propDict = new Dictionary<string, PropertyInfo>();

                if (reader != null && reader.HasRows)
                {
                    var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    reader.Read();
                    for (var index = 0; index < reader.FieldCount; index++)
                    {
                        if (propDict.ContainsKey(reader.GetName(index).ToUpper()))
                        {
                            var info = propDict[reader.GetName(index).ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = reader.GetValue(index);
                                info.SetValue(value, (val == DBNull.Value) ? null : val, null);
                            }
                        }
                    }
                }
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}