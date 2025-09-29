using Application.Repositories;
using Application.UseCases.Automovil.Commands.DeleteAutomovil;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.UseCases.Automovil.Commands.DeleteAutomovil
{
    internal sealed class DeleteAutomovilHandler : IRequestCommandHandler<DeleteAutomovilCommand, bool>
    {
        private readonly IAutomovilRepository _automovilRepository;

        // Constructor: Inyección del Repositorio
        public DeleteAutomovilHandler(IAutomovilRepository automovilRepository)
        {
            _automovilRepository = automovilRepository ?? throw new ArgumentNullException(nameof(automovilRepository));
        }

        // Método Handle: Aquí se ejecuta la lógica
        public async Task<bool> Handle(DeleteAutomovilCommand request, CancellationToken cancellationToken)
        {
            // Buscar la entidad por ID (usando el ID del comando).
            // El repositorio IAutomovilRepository, heredado de IRepository, tiene este método.
            var entity = await _automovilRepository.FindOneAsync(request.AutomovilId);

            //  Verificar si la entidad existe. Si es nula, devolvemos 'false'
            // para que el Controller devuelva el Status Code 404 (NotFound).
            if (entity == null)
            {
                return false;
            }

            _automovilRepository.Remove(request.AutomovilId);

            //  Devolvemos 'true' para que el Controller devuelva Status Code 200 (Ok).
            return true;
        }
    }
}