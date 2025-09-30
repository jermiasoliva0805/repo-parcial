using Application.Repositories;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAutomovilByChasis
{
   

    // El Handler debe coincidir con el tipo de Query y el tipo de resultado (Automovil)
    internal sealed class GetAutomovilByChasisQueryHandler : IRequestQueryHandler<GetAutomovilByChasisQuery, Domain.Entities.Automovil>
    {
        private readonly IAutomovilRepository _automovilRepository;

        // Inyección de dependencias
        public GetAutomovilByChasisQueryHandler(IAutomovilRepository automovilRepository)
        {
            _automovilRepository = automovilRepository;
        }

        public async Task<Domain.Entities.Automovil> Handle(GetAutomovilByChasisQuery request, CancellationToken cancellationToken)
        {
            // Usamos el método específico que definimos en IAutomovilRepository
            Domain.Entities.Automovil entity = await _automovilRepository.FindOneByChasisAsync(request.NumeroChasis);

            // Si lo encuentra, devuelve el objeto; si no, devuelve null.
            // El Controller se encarga de mapear el 'null' a 404.
            return entity;
        }
    }
}
