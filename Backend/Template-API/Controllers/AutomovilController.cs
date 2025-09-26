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
        return CreatedAtAction(nameof(GetById), new { id = id }, new { Id = id });
    }

    // ---------------------------------------------------------------------------------------
    // 6. GetAll (Obtener todos los automóviles registrados)
    // Método HTTP: GET | Ruta: /api/v1/automovil
    // Respuesta: 200 - Lista de objetos de automóviles.
    // ---------------------------------------------------------------------------------------
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AutomovilListDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        // El bus envía el Query para obtener todos los datos (posiblemente un DTO de lista)
        var query = new GetAllAutomovilesQuery();
        var result = await _commandQueryBus.Send(query);

        return Ok(result); // Status Code 200
    }

    // ---------------------------------------------------------------------------------------
    // 4. GetById (Obtener un automóvil por su ID)
    // Método HTTP: GET | Ruta: /api/v1/automovil/{id}
    // Respuesta: 200 - Objeto del automóvil o mensaje de error (404).
    // ---------------------------------------------------------------------------------------
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AutomovilDetailDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        // El bus envía el Query con el ID
        var query = new GetAutomovilByIdQuery(id);
        var result = await _commandQueryBus.Send(query);

        if (result == null)
        {
            return NotFound($"Automóvil con ID {id} no encontrado.");
        }
        return Ok(result); // Status Code 200
    }

    // ---------------------------------------------------------------------------------------
    // 5. GetByChasis (Obtener un automóvil por número de chasis)
    // Método HTTP: GET | Ruta: /api/v1/automovil/chasis/{numeroChasis}
    // Respuesta: 200 - Objeto del automóvil o mensaje de error (404).
    // ---------------------------------------------------------------------------------------
    [HttpGet("chasis/{numeroChasis}")] // Ruta específica para este endpoint
    [ProducesResponseType(typeof(AutomovilDetailDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByChasis(string numeroChasis)
    {
        // El bus envía el Query con el número de chasis
        var query = new GetAutomovilByChasisQuery(numeroChasis);
        var result = await _commandQueryBus.Send(query);

        if (result == null)
        {
            return NotFound($"Automóvil con número de chasis {numeroChasis} no encontrado.");
        }
        return Ok(result); // Status Code 200
    }

    // ---------------------------------------------------------------------------------------
    // 3. Update (Actualizar los datos de un automóvil)
    // Método HTTP: PUT | Ruta: /api/v1/automovil/{id}
    // Respuesta: Objeto actualizado o mensaje de error (404).
    // ---------------------------------------------------------------------------------------
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(AutomovilDetailDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(int id, UpdateAutomovilCommand command)
    {
        if (command is null || command.Id != id)
        {
            return BadRequest("El ID de la ruta no coincide con el ID del cuerpo de la solicitud.");
        }

        // El bus envía el comando y devuelve el objeto actualizado (según consigna)
        var result = await _commandQueryBus.Send(command);

        if (result == null)
        {
            return NotFound($"Automóvil con ID {id} no encontrado para actualizar.");
        }

        return Ok(result); // Status Code 200 (Devuelve el objeto actualizado, como pide la consigna)
    }

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
}