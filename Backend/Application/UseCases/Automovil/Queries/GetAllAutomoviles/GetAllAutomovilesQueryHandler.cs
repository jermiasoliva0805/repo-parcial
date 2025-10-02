using Application.Repositories;
using Core.Application;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAllAutomoviles
{
    
    internal sealed class GetAllAutomovilesQueryHandler :
        IRequestQueryHandler<GetAllAutomovilesQuery, List<Domain.Entities.Automovil>>
    {
        private readonly IAutomovilRepository _automovilRepository;

        public GetAllAutomovilesQueryHandler(IAutomovilRepository automovilRepository)
        {
            _automovilRepository = automovilRepository;
        }

        public async Task<List<Domain.Entities.Automovil>> Handle(GetAllAutomovilesQuery request, CancellationToken cancellationToken)
        {
            
           
            List<Domain.Entities.Automovil> entities = await _automovilRepository.FindAllAsync();

            
            

            return entities;
        }
    }
}