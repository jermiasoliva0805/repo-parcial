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

        
        public DeleteAutomovilHandler(IAutomovilRepository automovilRepository)
        {
            _automovilRepository = automovilRepository ?? throw new ArgumentNullException(nameof(automovilRepository));
        }

       
        public async Task<bool> Handle(DeleteAutomovilCommand request, CancellationToken cancellationToken)
        {
            
            var entity = await _automovilRepository.FindOneAsync(request.AutomovilId);

            
            
            if (entity == null)
            {
                return false;
            }

            _automovilRepository.Remove(request.AutomovilId);

            
            return true;
        }
    }
}