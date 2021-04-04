using Newtonsoft.Json;
using System;
using System.Xml.Linq;
using YAXLib;

namespace Netactica.Tools
{
    /// <summary>
    /// Clase para serializar y desiarlizar objetos en formato json y xml
    /// </summary>
    public class SerializeModel
    {
        /// <summary>
        /// Convierte un ojbeto a Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            try
            {
                if (obj == null) return string.Empty;
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Deserializa un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonvalue">json value</param>
        /// <returns></returns>
        public static T DeSerializeObject<T>(string jsonvalue)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonvalue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un objeto a xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Objeto</param>
        /// <returns>xml</returns>
        public static string ObjetToXML<T>(T obj)
        {
            try
            {
                var serializer = new YAXSerializer(typeof(T));
                string xml = serializer.Serialize(obj);
                return xml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un objet a XDocument
        /// </summary>
        /// <typeparam name="T">tipo t</typeparam>
        /// <param name="obj">objeto a serializar</param>
        /// <returns>XDocument</returns>
        public static XDocument ObjetToXMLDocument<T>(T obj)
        {
            try
            {
                var serializer = new YAXSerializer(typeof(T));
                var xml = serializer.SerializeToXDocument(obj);
                return xml;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Convierte un xml a un objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">xml</param>
        /// <returns>T</returns>
        public static T XMLToObject<T>(string xml)
        {
            try
            {
                var serializer = new YAXSerializer(typeof(T));
                return (T)serializer.Deserialize(xml);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}