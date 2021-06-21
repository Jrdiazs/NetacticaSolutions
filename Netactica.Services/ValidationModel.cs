using FluentValidation;
using Netactica.Models;
using Netactica.Tools.StringTools;
using System;

namespace Netactica.Services
{
    public class ReservasValidator : ValidatorModel<Reservas>
    {
        public ReservasValidator()
        {
            RuleFor(x => x.ReservaId).NotEmpty().WithMessage($"El id de la reservar no pueder ser vacio o igual a {Guid.Empty}");
            RuleFor(x => x.DocumentoIdentidad).NotEmpty().WithMessage("El documento de identidad no pueder ser vacio");
            RuleFor(x => x.TipoIdentificacionId).
                GreaterThan(0).WithMessage("El tipo de documento no puede ser menor o igual a 0");

            RuleFor(x => x.FechaHoraPickup).NotEmpty().WithMessage("La fecha de recogida del auto no puede ser vacia").
                NotEqual(DateTime.MinValue).WithMessage($"La fecha de recogida del auto puede ser igual a {DateTime.MinValue}").
                Custom((x, y) =>
                {
                    if (!x.ValidSqlDateTime())
                    {
                        y.AddFailure("Fecha de recogida inválida");
                    }
                });

            RuleFor(x => x.FechaHoraDropoff).NotEmpty().WithMessage("La fecha de entrega del auto no puede ser vacia").
               NotEqual(DateTime.MinValue).WithMessage($"La fecha de entrega del auto puede ser igual a {DateTime.MinValue}").
               Custom((x, y) =>
               {
                   if (!x.ValidSqlDateTime())
                   {
                       y.AddFailure("Fecha de entrega inválida");
                   }
               });

            RuleFor(x => x.FechaCreacion).NotEmpty().WithMessage("La fecha de creación no puede ser vacia").
              NotEqual(DateTime.MinValue).WithMessage($"La fecha de creación no puede ser igual a {DateTime.MinValue}").
              Custom((x, y) =>
              {
                  if (!x.ValidSqlDateTime())
                  {
                      y.AddFailure("Fecha de creación inválida");
                  }
              });

            RuleFor(x => x.LugarPickup).NotEmpty().WithMessage("El Lugar de recogida del vehiculo no pueder ser vacio").
                MaximumLength(500).WithMessage("El Lugar de recogida no pueden pasar de 500 caracteres");

            RuleFor(x => x.LugarDropoff).NotEmpty().WithMessage("El Lugar de entrega del vehiculo no pueder ser vacio").
                MaximumLength(500).WithMessage("El Lugar de entrega no pueden pasar de 500 caracteres");

            RuleFor(x => x.Marca).NotEmpty().WithMessage("La marca del carro no pueder ser vacia");
            RuleFor(x => x.Modelo).NotEmpty().WithMessage("La modelo no pueder ser vacio");
            RuleFor(x => x.Nombres).NotEmpty().WithMessage("Los nombres del tomador no pueden ser vacios").
                MaximumLength(100).WithMessage("Los nombres no pueden pasar de 100 caracteres");

            RuleFor(x => x.Apellidos).NotEmpty().WithMessage("Los apellidos del tomador no pueden ser vacios").
                MaximumLength(100).WithMessage("Los Apellidos no pueden pasar de 100 caracteres");

            RuleFor(x => x.PrecioPorHora).
                GreaterThan(0).WithMessage("El precio por hora no puede ser menor o igual a 0");
        }
    }


    /// <summary>
    /// Plantilla para crear validadores de modelos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ValidatorModel<T> : AbstractValidator<T>, IValidatorModel<T>
    {
    }

    /// <summary>
    /// Plantilla para crear validadores de modelos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidatorModel<T> : IValidator<T> { }
}