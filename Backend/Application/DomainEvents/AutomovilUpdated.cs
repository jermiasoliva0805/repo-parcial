using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;


namespace Application.DomainEvents
{
    internal sealed class Automovil : DomainEvent
    {
        public int AutomovilIdProperty { get; set; }
        public string AutomovilPropertyOne { get; set; }
        public AutomovilValues AutomovilPropertyTwo { get; set; }
    }
}
