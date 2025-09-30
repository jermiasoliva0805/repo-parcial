using Core.Application;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.UseCases.Automovil.Queries.GetAllAutomoviles
{
    // 1. Hereda de IRequestQuery<TResult>. El resultado es la lista de entidades.
    // Usaremos List<T> para mantener la consistencia con tu IRepository<T>.
    public class GetAllAutomovilesQuery : IRequestQuery<List<Domain.Entities.Automovil>>
    {
        // Esta Query no necesita datos de entrada.
        public GetAllAutomovilesQuery() { }
    }
}