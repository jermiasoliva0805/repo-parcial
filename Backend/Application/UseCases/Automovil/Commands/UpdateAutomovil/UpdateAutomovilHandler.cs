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

namespace ESCMB.Application.UseCases.Automovil.Commands.UpdateAutomovil
{
    internal sealed class UpdateAutomovilHandler(ICommandQueryBus domainBus, IAutomovilRepository automovilRepository) : IRequestCommandHandler<UpdateAutomovilCommand>
    {
        private readonly ICommandQueryBus _domainBus = domainBus ?? throw new ArgumentNullException(nameof(domainBus));
        private readonly IAutomovilRepository _context = automovilRepository ?? throw new ArgumentNullException(nameof(automovilRepository));

        public async Task Handle(UpdateAutomovilCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Automovil entity = await _context.FindOneAsync(request.Marca) ?? throw new EntityDoesNotExistException();
            entity.SetautomovilPropertyOne(request.AutomovilPropertyOne);
            entity.SetautomovilPropertyTwo(request.AutomovilPropertyTwo);

            try
            {
                _context.Update(request.Marca, entity);

                await _domainBus.Publish(entity.To<AutomovilUpdated>(), cancellationToken);
            }
            catch (Exception ex)
            {
                throw new BussinessException(ApplicationConstants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}

