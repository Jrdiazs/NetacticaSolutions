using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Netactica.Tools.StringTools
{
    public static class StringUtil
    {
        /// <summary>
        /// Determina si un string es null o vacio
        /// </summary>
        /// <param name="value">valor string</param>
        /// <returns>true si es vacio, false si no es vacio</returns>
        public static bool IsEmpty(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) return true;
                if (string.IsNullOrWhiteSpace(value)) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SerializeObject(this object obj)
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

        public static bool IsBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Realiza un Like sql
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string LikeSql(this string value)
        {
            try
            {
                if (value.IsEmpty())
                    value = string.Empty;

                value = value.Replace("[", "[[]").Replace("%", "[%]");

                value = string.Format("{0}{1}{0}", "%", value);

                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene el key establecido en el web config por llave
        /// </summary>
        /// <param name="keyvalue">nombre de la llave</param>
        /// <param name="valuedefault">valor por default si no se encuentra la llave en el web config</param>
        /// <returns></returns>
        public static string ReadKey(this string keyvalue, string valuedefault = "")
        {
            try
            {
                if (keyvalue.IsEmpty())
                    throw new ArgumentNullException("value no puede ser null");

                return ConfigurationManager.AppSettings[keyvalue] ?? valuedefault;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee una cadena de conexion del web config
        /// </summary>
        /// <param name="keyvalue">valor de la llave del web config</param>
        /// <returns>string connections</returns>
        public static string ReadConnections(this string keyvalue)
        {
            try
            {
                if (keyvalue.IsEmpty())
                    throw new ArgumentNullException("value no puede ser null");

                return ConfigurationManager.ConnectionStrings[keyvalue].ConnectionString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Encripta a base 64 una cadena de texto
        /// </summary>
        /// <param name="value">valor a encriptar</param>
        /// <returns></returns>
        public static string Base64Encode(this string value)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desencripta una cadena de texto
        /// </summary>
        /// <param name="value">cadena de texto</param>
        /// <returns>string a codificar</returns>
        public static string Base64Decode(this string value)
        {
            try
            {
                if (value.IsEmpty())
                    return string.Empty;
                return Encoding.UTF8.GetString(Convert.FromBase64String(value));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Verifica si un caracter es una letra
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsLetter(this char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
        }

        /// <summary>
        /// Verifica si un caracter contiene un numero
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsDigit(this char c)
        {
            return c >= '0' && c <= '9';
        }

        /// <summary>
        /// Verifica si es un caracter especial
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSymbol(this char c)
        {
            return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
        }

        /// <summary>
        /// Lee el valor de una llave del web config
        /// </summary>
        /// <param name="value">nombre de la llave del web config</param>
        /// <param name="defaultValue">valor por default si no esta escrita la llave en el web config</param>
        /// <returns></returns>
        public static string ReadAppConfig(this string value, string defaultValue = null)
        {
            try
            {
                return !value.IsEmpty() ? ConfigurationManager.AppSettings[value] : (defaultValue.IsEmpty() ? string.Empty : defaultValue);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina todos los espacion de una cadena de texto
        /// </summary>
        /// <param name="value">valor a quitar los espacios</param>
        /// <returns></returns>
        public static string RemoveSpace(this string value)
        {
            try
            {
                if (value.IsEmpty())
                    return string.Empty;

                var TAB = '\t';
                var SALTO = '\n';
                var CONTROL = '\r';
                return value.Replace(TAB.ToString(), string.Empty).Replace(SALTO.ToString(), string.Empty).Replace(CONTROL.ToString(), string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina todos los espacios dobles de una cadena de texto
        /// </summary>
        /// <param name="value">valor a quitar los espacios</param>
        /// <returns></returns>
        public static string TrimAll(this string value)
        {
            try
            {
                if (value.IsEmpty())
                    return string.Empty;
                value = value.Trim();
                value = Regex.Replace(value, "\\s+", " ");
                return RemoveSpace(value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida un datetime para sql server
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool ValidSqlDateTime(this DateTime date) 
        {
            return ((date >= (DateTime)SqlDateTime.MinValue) && (date <= (DateTime)SqlDateTime.MaxValue));
        }

        /// <summary>
        /// Encripta una cadena segun la llave establecida
        /// </summary>
        /// <param name="value">valor a encriptar</param>
        /// <param name="key">llave de encriptacion</param>
        /// <returns>cadena encriptada</returns>
        public static string Encode(this string value, string key)
        {
            try
            {
                var encode = string.Empty;

                using (var desCrypto = new TripleDESCryptoServiceProvider())
                using (var md5 = new MD5CryptoServiceProvider())
                using (var memoryStream = new MemoryStream())
                {
                    var inputArray = Encoding.UTF8.GetBytes(value);

                    var cyphMode = CipherMode.ECB;

                    desCrypto.Key = md5.ComputeHash(Encoding.ASCII.GetBytes(key));
                    desCrypto.Mode = cyphMode;

                    desCrypto.IV = Encoding.ASCII.GetBytes(key);

                    using (var crypto = new CryptoStream(memoryStream, desCrypto.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        crypto.Write(inputArray, 0, inputArray.Length);
                        crypto.FlushFinalBlock();
                    }

                    var ret = memoryStream.ToArray();

                    encode = Convert.ToBase64String(ret);
                }
                return encode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Desencripta una cadena codificada con el algoritmo de brinks
        /// </summary>
        /// <param name="value">valor a desencriptar</param>
        /// <param name="Key">llave de encriptacion</param>
        /// <returns>cadena desencriptada</returns>
        public static string Decode(this string value, string Key)
        {
            try
            {
                var decode = string.Empty;
                var inputBytes = Convert.FromBase64String(value);
                using (var desCrypto = new TripleDESCryptoServiceProvider())
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var cyphMode = CipherMode.ECB;

                    desCrypto.Key = md5.ComputeHash(Encoding.ASCII.GetBytes(Key));
                    desCrypto.Mode = cyphMode;

                    desCrypto.IV = Encoding.ASCII.GetBytes(Key);

                    using (var memoryStream = new MemoryStream(inputBytes))
                    {
                        var desencriptor = new CryptoStream(memoryStream, desCrypto.CreateDecryptor(), CryptoStreamMode.Read);
                        var buffer = new byte[inputBytes.Length];
                        desencriptor.Read(buffer, 0, buffer.Length);

                        decode = Encoding.ASCII.GetString(buffer);

                        if (!string.IsNullOrEmpty(decode))
                            decode = decode.Replace("\0", string.Empty);
                    }
                }

                return decode;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Determina si un valor string es numerico
        /// </summary>
        /// <param name="value">valor string</param>
        /// <returns>true or false</returns>
        public static bool IsNumber(this string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return false;

                var regex = new Regex(@"^[0-9]*$");
                return regex.IsMatch(value);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}