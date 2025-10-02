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
        
        public int AutomovilId { get; set; }

                     
        public GetAutomovilByIdQuery(int id)
        {
            AutomovilId = id;
        }
    }
}

