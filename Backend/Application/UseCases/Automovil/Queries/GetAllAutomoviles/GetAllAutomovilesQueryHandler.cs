using Application.Repositories;
using Core.Application;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Queries.GetAllAutomoviles
{
    // 2. Implementa IRequestQueryHandler, manejando la Query y devolviendo el List<Automovil>
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
            // 3. Llama al método FindAllAsync() del repositorio.
            // Esto devolverá la lista de entidades.
            List<Domain.Entities.Automovil> entities = await _automovilRepository.FindAllAsync();

            // Nota: Aquí se podría mapear a un DTO si la capa de presentación lo necesitara,
            // pero para simplificar, devolvemos la entidad de Dominio directamente.

            return entities;
        }
    }
}