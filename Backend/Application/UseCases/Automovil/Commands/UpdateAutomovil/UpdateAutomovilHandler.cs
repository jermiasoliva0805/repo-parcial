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


namespace Application.UseCases.Automovil.Commands.UpdateAutomovil
{
    
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
            
            Domain.Entities.Automovil entity = await _automovilRepository.FindOneAsync(request.AutomovilId);
            
            if (entity == null)
            {
                return false;
            }

            
            entity.UpdateColor(request.Color);
            entity.UpdateNumeroMotor(request.NumeroMotor);

            
            

            try
            {
                
                _automovilRepository.Update(request.AutomovilId, entity);

               
                

                return true;
            }
            catch (Exception ex)
            {
                throw new BussinessException(ApplicationConstants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}