using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Automovil.Commands.DeleteAutomovil
{
    public class DeleteAutomovilCommand : IRequestCommand<bool>
    {
        // Solo necesitamos el ID para saber qué automóvil eliminar	
        public int AutomovilId { get; set; }
        public DeleteAutomovilCommand(int id)
        {
            AutomovilId = id;
        }
    }
    
}
