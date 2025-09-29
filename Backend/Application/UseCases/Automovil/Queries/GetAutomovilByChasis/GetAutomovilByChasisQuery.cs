using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAutomovilByChasis
{
    // Usamos IRequestQuery<TResult>
    public class GetAutomovilByChasisQuery : IRequestQuery<Domain.Entities.Automovil>
    {
        // El parámetro de búsqueda que viene de la ruta del Controller
        public string NumeroChasis { get; set; }

        // Constructor para inicializar el valor desde el Controller
        public GetAutomovilByChasisQuery(string numeroChasis)
        {
            NumeroChasis = numeroChasis;
        }
    }
}
