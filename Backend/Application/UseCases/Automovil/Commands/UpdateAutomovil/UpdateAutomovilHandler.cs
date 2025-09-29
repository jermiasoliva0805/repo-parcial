using Application.Constants;
using Application.DomainEvents;
using Application.Exceptions;
using Application.Repositories;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;
using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Nota: Asegúrate de que este namespace coincida con la ubicación real de tu archivo
namespace Application.UseCases.Automovil.Commands.UpdateAutomovil
{
    // Usamos 'public' o 'internal sealed' (tu preferencia) y devolvemos 'bool'
    internal sealed class UpdateAutomovilHandler : IRequestCommandHandler<UpdateAutomovilCommand, bool>
    {
        private readonly ICommandQueryBus _domainBus;
        private readonly IAutomovilRepository _automovilRepository;

        public UpdateAutomovilHandler(ICommandQueryBus domainBus, IAutomovilRepository automovilRepository)
        {
            _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
            _automovilRepository = automovilRepository ?? throw new ArgumentNullException(nameof(automovilRepository));
        }

        public async Task<bool> Handle(UpdateAutomovilCommand request, CancellationToken cancellationToken)
        {
            // 1. Buscar la entidad por ID
            Domain.Entities.Automovil entity = await _automovilRepository.FindOneAsync(request.AutomovilId);
            // 2. Verificar si existe (devolver false para que el Controller mapee a 404)
            if (entity == null)
            {
                return false;
            }

            // 3. Aplicar los cambios: Los métodos de la Entidad ignorarán los valores nulos/vacíos omitidos en el JSON.
            entity.UpdateColor(request.Color);
            entity.UpdateNumeroMotor(request.NumeroMotor);

            // Opcional: Validar la entidad si tienes reglas complejas post-actualización
            // if (!entity.IsValid) throw new InvalidEntityDataException(entity.GetErrors());

            try
            {
                // 4. Persistir los cambios (Usando el ID y la entidad actualizada)
                _automovilRepository.Update(request.AutomovilId, entity);

                // 5. Opcional: Publicar evento (si lo tienes implementado)
                // await _domainBus.Publish(entity.To<AutomovilUpdated>(), cancellationToken); 

                return true;
            }
            catch (Exception ex)
            {
                throw new BussinessException(ApplicationConstants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}