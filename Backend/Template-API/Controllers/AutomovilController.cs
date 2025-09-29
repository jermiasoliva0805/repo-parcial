using Application.UseCases.Automovil.Commands.DeleteAutomovil;
using Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using Controllers;
using Core.Application;
using MediatR; // O la referencia a tu librería de ICommandQueryBus
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.UseCases.Automovil.Commands.UpdateAutomovil;


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

    public AutomovilController(ICommandQueryBus commandQueryBus)
    {
        _commandQueryBus = commandQueryBus ?? throw new
            ArgumentNullException(nameof(commandQueryBus));
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

        return Ok(new { Message = $"Automóvil con ID {id} eliminado correctamente." }); // Status Code 200 (como pide la consigna)
    }

    [HttpPut("api/v1/[Controller]/{id}")]
    public async Task<IActionResult> Update(UpdateAutomovilCommand command)
    {
        if (command is null) return BadRequest();

        await _commandQueryBus.Send(command);

        return NoContent();
    }
}