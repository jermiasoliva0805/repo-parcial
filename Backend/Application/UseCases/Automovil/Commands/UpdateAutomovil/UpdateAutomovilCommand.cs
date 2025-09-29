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
    public class UpdateAutomovilCommand : IRequestCommand
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Color { get; private set; }
        public int Fabricacion { get; private set; }
        public string NumeroMotor { get; private set; }
        public string NumeroChasis { get; private set; }
        public string CodigoInterno { get; private set; }

        public string AutomovilPropertyOne { get; set; }
        public AutomovilValues AutomovilPropertyTwo { get; set; }


    }
}

