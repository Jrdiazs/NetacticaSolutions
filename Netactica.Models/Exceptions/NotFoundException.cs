using System;

namespace Netactica.Models.Exceptions
{
    /// <summary>
    /// Clase de excepciones cuando no existe un dato
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// Clase de excepciones cuando no existe un dato
        /// </summary>
        public NotFoundException() : base()
        {
        }

        /// <summary>
        /// Clase de excepciones cuando no existe un dato, con un mensaje de error
        /// </summary>
        /// <param name="message">mensaje de error</param>
        public NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Clase de excepciones cuando no existe un dato, con un mensaje de error,excepcion ya creada
        /// </summary>
        /// <param name="message">mensaje de error</param>
        /// <param name="inner">excepcion ya creada</param>
        public NotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}