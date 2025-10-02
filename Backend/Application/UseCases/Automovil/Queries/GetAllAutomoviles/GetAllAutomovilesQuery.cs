using Core.Application;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.UseCases.Automovil.Queries.GetAllAutomoviles
{
    
    public class GetAllAutomovilesQuery : IRequestQuery<List<Domain.Entities.Automovil>>
    {
        
        public GetAllAutomovilesQuery() { }
    }
}