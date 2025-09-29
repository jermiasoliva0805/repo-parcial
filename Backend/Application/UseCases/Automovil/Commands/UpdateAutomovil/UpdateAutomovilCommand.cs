using Core.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;


namespace Application.UseCases.Automovil.Commands.UpdateAutomovil
{
    // El Command debe devolver 'bool' para que el Controller sepa si se encontró o no
    public class UpdateAutomovilCommand : IRequestCommand<bool>
    {
        // El ID que viene de la ruta del Controller
        public int AutomovilId { get; set; }

        // Propiedades a actualizar (vienen del cuerpo JSON)
        public string Color { get; set; }
        public string NumeroMotor { get; set; }

        // Constructor requerido para el binding en el Controller
        public UpdateAutomovilCommand() { }
    }
}

