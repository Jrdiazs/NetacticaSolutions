using System;

namespace Netactica.Models.Exceptions
{
    /// <summary>
    /// Clase excepciones para validaciones de negocio
    /// </summary>
    public class BusinessException : Exception
    {
        /// <summary>
        ///  Clase excepciones para validaciones de negocio
        /// </summary>
        public BusinessException() : base()
        {
        }

        /// <summary>
        ///  Clase excepciones para validaciones de negocio instanciado con un mensaje de error
        /// </summary>
        /// <param name="message">mensaje de error</param>
        public BusinessException(string message) : base(message)
        {
        }

        /// <summary>
        /// Clase excepciones para validaciones de negocio instanciado con un mensaje de error y una excepcion ya creada
        /// </summary>
        /// <param name="message">mensaje de error</param>
        /// <param name="inner">excepcion ya creada</param>
        public BusinessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}