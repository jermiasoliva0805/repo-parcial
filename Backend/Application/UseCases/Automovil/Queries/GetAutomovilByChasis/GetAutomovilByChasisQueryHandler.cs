using Application.Repositories;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAutomovilByChasis
{
   

    
    internal sealed class GetAutomovilByChasisQueryHandler : IRequestQueryHandler<GetAutomovilByChasisQuery, Domain.Entities.Automovil>
    {
        private readonly IAutomovilRepository _automovilRepository;

        
        public GetAutomovilByChasisQueryHandler(IAutomovilRepository automovilRepository)
        {
            _automovilRepository = automovilRepository;
        }

        public async Task<Domain.Entities.Automovil> Handle(GetAutomovilByChasisQuery request, CancellationToken cancellationToken)
        {
            
            Domain.Entities.Automovil entity = await _automovilRepository.FindOneByChasisAsync(request.NumeroChasis);

            
           
            return entity;
        }
    }
}
