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
    
    public class UpdateAutomovilCommand : IRequestCommand<bool>
    {
        
        public int AutomovilId { get; set; }

        
        public string Color { get; set; }
        public string NumeroMotor { get; set; }

        
        public UpdateAutomovilCommand() { }
    }
}

