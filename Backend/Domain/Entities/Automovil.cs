using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Validators;
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
        protected Automovil() { }
        public Automovil(string marca, string modelo, int fabricacion, string
       numeroMotor, string numeroChasis)
        {
            Marca = marca;
            Modelo = modelo;
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
    }

}
