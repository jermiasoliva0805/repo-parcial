using Application.Repositories;
using Application.UseCases.Automovil.Commands.DeleteAutomovil;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;
using Application.UseCases.Automovil.Queries.GetAllAutomoviles;
using Application.UseCases.Automovil.Queries.GetAutomovilByChasis;
using Application.UseCases.Automovil.Queries.GetAutomovilById;
using Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using Controllers;
using Core.Application;
using MediatR; 
using Microsoft.AspNetCore.Mvc;
using System.Net;





[ApiController]
[Route("api/v1/[controller]")]

public class AutomovilController : BaseController
{
    
    private readonly ICommandQueryBus _commandQueryBus;
    private readonly IAutomovilRepository _automovilRepository;

    public AutomovilController(IAutomovilRepository automovilRepository, ICommandQueryBus commandQueryBus)
    {
        _commandQueryBus = commandQueryBus ?? throw new
            ArgumentNullException(nameof(commandQueryBus));

        _automovilRepository = automovilRepository;
        _commandQueryBus = commandQueryBus;
    }
   
    
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateAutomovilCommand command)
    {
        if (command is null) return BadRequest("El cuerpo de la solicitud no puede ser nulo.");

        
        var id = await _commandQueryBus.Send(command);

        
        return Created($"api/v1/[controller]/{id}", new { Id = id });
    }

   
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAutomovilCommand(id);

      
        var deletedSuccessfully = await _commandQueryBus.Send(command);

        if (!deletedSuccessfully)
        {
            return NotFound($"Automóvil con ID {id} no encontrado para eliminar.");
        }

        return Ok(new { Message = $"Automóvil con ID {id} eliminado correctamente." }); 
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAutomovilCommand command)
    {
        command.AutomovilId = id; 

        var result = await _commandQueryBus.Send(command);

        if (!result)
            return NotFound(new { mensaje = $"Automovil con ID {id} no encontrado" });

       
        var automovilActualizado = await _automovilRepository.FindOneAsync(id);

       
        return Ok(new { mensaje = "Automovil actualizado correctamente" }); 
    }

   
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        
        var query = new GetAutomovilByIdQuery(id);

        
        var automovil = await _commandQueryBus.Send(query);

        
        if (automovil is null)
        {
            
            return NotFound($"Automóvil con ID {id} no encontrado.");
        }

       
        return Ok(automovil);

    }


    [HttpGet("chasis/{numeroChasis}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]        
    [ProducesResponseType((int)HttpStatusCode.NotFound)]  
    public async Task<IActionResult> GetByChasis([FromRoute] string numeroChasis)
    {
        
        var query = new GetAutomovilByChasisQuery(numeroChasis);

        
        var automovil = await _commandQueryBus.Send(query);

        
        if (automovil is null)
        {
            
            return NotFound($"Automóvil con chasis {numeroChasis} no encontrado.");
        }

        
        return Ok(automovil);
    }


    [HttpGet] 
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        
        var query = new GetAllAutomovilesQuery();

       
        
        var automoviles = await _commandQueryBus.Send(query);

        
       
        return Ok(automoviles);
    }
}
