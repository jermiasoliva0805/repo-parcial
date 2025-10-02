using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validators;
using static Domain.Enums.Enums;
namespace Domain.Entities
{
    public class Automovil : DomainEntity<int, AutomovilValidator>
    {
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string Color { get; private set; }
        public int Fabricacion { get; private set; }
        public string NumeroMotor { get; private set; }
        public string NumeroChasis { get; private set; }
        public string CodigoInterno { get; private set; }

        public string AutomovilPropertyOne { get; private set; }
        public AutomovilValues AutomovilPropertyTwo { get; private set; }
        protected Automovil() { }
        public Automovil(string marca, string modelo, string color, int fabricacion, string numeroMotor, string numeroChasis)
        {
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Fabricacion = fabricacion;
            NumeroMotor = numeroMotor;
            NumeroChasis = numeroChasis;
            CodigoInterno = GenerarCodigoInterno(marca, modelo);
        }
        private string GenerarCodigoInterno(string marca, string modelo)
        {
            return $"{marca.Substring(0, 3).ToUpper()}-{modelo.Substring(0,
           3).ToUpper()}-{DateTime.Now:yyyyMMddHHmmss}";
        }

        public void SetautomovilPropertyOne(string value)
        {
           AutomovilPropertyOne = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void SetautomovilPropertyTwo(AutomovilValues value)
        {
           AutomovilPropertyTwo = value;
        }

        public void UpdateColor(string newColor)
        {
           
            if (!string.IsNullOrEmpty(newColor))
            {
                Color = newColor;
            }
        }

        public void UpdateNumeroMotor(string newNumeroMotor)
        {
            
            if (!string.IsNullOrEmpty(newNumeroMotor))
            {
                NumeroMotor = newNumeroMotor;
            }
        }

    }

}
