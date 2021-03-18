using Netactica.Models.Exceptions;
using System;
using System.Collections.Generic;

namespace Netactica.Services
{
    /// <summary>
    /// Clase base para negocio
    /// </summary>
    public class BaseServices : IBaseServices
    {
        public BaseServices()
        {
        }

        /// <summary>
        /// Realiza la validacion del modelo segun su clase validador, genera una excepcion BusinessException
        /// si encuentra un error en el modelo
        /// </summary>
        /// <typeparam name="T">Model T</typeparam>
        /// <typeparam name="ValidatorTModel">Clase validador</typeparam>
        /// <param name="model">Model</param>
        public void Validator<T, ValidatorTModel>(T model) where ValidatorTModel : IValidatorModel<T>, new()
        {
            try
            {
                var validator = new ValidatorTModel();
                var results = validator.Validate(model);

                if (results.IsValid)
                    return;

                var msg = new List<string>();
                foreach (var error in results.Errors)
                    msg.Add(error.ErrorMessage);

                throw new BusinessException(string.Join(",", msg));
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
    }

    /// <summary>
    /// Clase base para negocio
    /// </summary>
    public interface IBaseServices
    {
        /// <summary>
        /// Realiza la validacion del modelo segun su clase validador, genera una excepcion BusinessException
        /// si encuentra un error en el modelo
        /// </summary>
        /// <typeparam name="T">Model T</typeparam>
        /// <typeparam name="ValidatorTModel">Clase validador</typeparam>
        /// <param name="model">Model</param>
        void Validator<T, ValidatorTModel>(T model) where ValidatorTModel : IValidatorModel<T>, new();
    }
}