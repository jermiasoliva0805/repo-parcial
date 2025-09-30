using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAutomovilById
{
   
    public class GetAutomovilByIdQuery : IRequestQuery<Domain.Entities.Automovil>
    {
        // El ID que viene de la ruta del Controller
        public int AutomovilId { get; set; }

        // Constructor para inicializar el ID desde el Controller             
        public GetAutomovilByIdQuery(int id)
        {
            AutomovilId = id;
        }
    }
}

