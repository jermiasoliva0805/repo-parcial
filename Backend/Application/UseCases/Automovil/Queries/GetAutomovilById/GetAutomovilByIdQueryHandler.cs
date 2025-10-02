using Application.Repositories;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAutomovilById
{
    internal sealed class GetAutomovilByIdQueryHandler : IRequestQueryHandler<GetAutomovilByIdQuery, Domain.Entities.Automovil>
    {
        private readonly IAutomovilRepository _automovilRepository;

        
        public GetAutomovilByIdQueryHandler(IAutomovilRepository automovilRepository)
        {
            _automovilRepository = automovilRepository;
        }

        public async Task<Domain.Entities.Automovil> Handle(GetAutomovilByIdQuery request, CancellationToken cancellationToken)
        {
            
            
            Domain.Entities.Automovil entity = await _automovilRepository.FindOneAsync(request.AutomovilId);

            return entity;
        }
    }
}
