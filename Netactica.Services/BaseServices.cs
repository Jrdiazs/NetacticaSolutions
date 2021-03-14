using FluentValidation;
using Netactica.Models.Exceptions;
using System;
using System.Collections.Generic;

namespace Netactica.Services
{
    public class BaseServices : IBaseServices
    {
        public BaseServices()
        {
        }

        public void Validator<T, ValidatorModel>(T model, ValidatorModel validator) where ValidatorModel : IValidator
        {
            try
            {
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

    public interface IBaseServices
    {
        void Validator<T, ValidatorModel>(T model, ValidatorModel validator) where ValidatorModel : IValidator;
    }
}