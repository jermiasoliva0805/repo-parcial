using Application.Repositories;
using Application.UseCases.Automovil.Commands.DeleteAutomovil;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;
using Application.UseCases.Automovil.Queries.GetAutomovilById;
using Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using Controllers;
using Core.Application;
using MediatR; // O la referencia a tu librería de ICommandQueryBus
using Microsoft.AspNetCore.Mvc;
using System.Net;


// NOTA: Reemplaza estos 'usings' con la ubicación real de tus Comandos, Queries y DTOs
// using AUTOMOVIL10.Application.Automoviles.Commands;
// using AUTOMOVIL10.Application.Automoviles.Queries;
// using AUTOMOVIL10.Application.Automoviles.Dtos;


// La ruta base para todos los endpoints es /api/v1/automovil
[ApiController]
[Route("api/v1/[controller]")]
// [controller] se resuelve a "Automovil" en tiempo de ejecución.
public class AutomovilController : BaseController // Asumo que BaseController está definido
{
    // Utilizaré IMediator como placeholder para ICommandQueryBus, que es su rol común
    private readonly ICommandQueryBus _commandQueryBus;
    private readonly IAutomovilRepository _automovilRepository;

    public AutomovilController(IAutomovilRepository automovilRepository, ICommandQueryBus commandQueryBus)
    {
        _commandQueryBus = commandQueryBus ?? throw new
            ArgumentNullException(nameof(commandQueryBus));

        _automovilRepository = automovilRepository;
        _commandQueryBus = commandQueryBus;
    }
   
    // ---------------------------------------------------------------------------------------
    // 1. Create (Crear un nuevo automóvil)
    // Método HTTP: POST | Ruta: /api/v1/automovil
    // Respuesta: 201 - Objeto del automóvil creado con su id asignado.
    // ---------------------------------------------------------------------------------------
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Create(CreateAutomovilCommand command)
    {
        if (command is null) return BadRequest("El cuerpo de la solicitud no puede ser nulo.");

        // El bus envía el comando de creación y espera el ID del nuevo recurso.
        var id = await _commandQueryBus.Send(command);

        // La respuesta CreatedAtAction devuelve el status 201.
        //return CreatedAtAction(nameof(GetById), new { id = id }, new { Id = id });
        return Created($"api/v1/[controller]/{id}", new { Id = id });
    }

    // ---------------------------------------------------------------------------------------
    // 6. GetAll (Obtener todos los automóviles registrados)
    // Método HTTP: GET | Ruta: /api/v1/automovil
    // Respuesta: 200 - Lista de objetos de automóviles.
    // ---------------------------------------------------------------------------------------
   

   

    // ---------------------------------------------------------------------------------------
    // 2. Delete (Eliminar un automóvil por ID)
    // Método HTTP: DELETE | Ruta: /api/v1/automovil/{id}
    // Respuesta: 200 Confirmación de eliminación o mensaje de error (404).
    // ---------------------------------------------------------------------------------------
    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteAutomovilCommand(id);

        // Se asume que el comando devuelve un booleano o el objeto eliminado. 
        // Si no se encuentra, el CommandHandler debería lanzar una excepción
        // o devolver 'false', lo que aquí se mapea a NotFound.
        var deletedSuccessfully = await _commandQueryBus.Send(command);

        if (!deletedSuccessfully)
        {
            return NotFound($"Automóvil con ID {id} no encontrado para eliminar.");
        }

        return Ok(new { Message = $"Automóvil con ID {id} eliminado correctamente." }); // Status Code 200 
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
        // (La ruta le pasa el ID)
        var query = new GetAutomovilByIdQuery(id);

        //  (El Handler devolverá la entidad o null)
        var automovil = await _commandQueryBus.Send(query);

        // Verificar el resultado
        if (automovil is null)
        {
            // Si el Handler devuelve null, respondemos 404 Not Found
            return NotFound($"Automóvil con ID {id} no encontrado.");
        }

        //  Si encontramos la entidad, respondemos 200 OK con el objeto
        return Ok(automovil);
    }
}