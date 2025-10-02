using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAutomovilByChasis
{
    
    public class GetAutomovilByChasisQuery : IRequestQuery<Domain.Entities.Automovil>
    {
        
        public string NumeroChasis { get; set; }

        
        public GetAutomovilByChasisQuery(string numeroChasis)
        {
            NumeroChasis = numeroChasis;
        }
    }
}
