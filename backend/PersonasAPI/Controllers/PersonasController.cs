using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonasAPI.Commands;
using PersonasAPI.DTOs;
using PersonasAPI.Queries;

namespace PersonasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreatePersonaDto> _createValidator;
        private readonly IValidator<UpdatePersonaDto> _updateValidator;

        public PersonasController(
            IMediator mediator,
            IValidator<CreatePersonaDto> createValidator,
            IValidator<UpdatePersonaDto> updateValidator)
        {
            _mediator = mediator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        // GET: api/personas
        [HttpGet]
        public async Task<ActionResult<List<PersonaResponseDto>>> GetAll()
        {
            var query = new GetAllPersonasQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET: api/personas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaResponseDto>> GetById(Guid id)
        {
            var query = new GetPersonaByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new { mensaje = "Persona no encontrada" });

            return Ok(result);
        }

        // GET: api/personas/buscar?nombre=juan
        [HttpGet("buscar")]
        public async Task<ActionResult<List<PersonaResponseDto>>> SearchByName([FromQuery] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return BadRequest(new { mensaje = "El parámetro 'nombre' es obligatorio" });

            var query = new SearchPersonasByNameQuery(nombre);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST: api/personas
        [HttpPost]
        public async Task<ActionResult<PersonaResponseDto>> Create([FromBody] CreatePersonaDto persona)
        {
            var validationResult = await _createValidator.ValidateAsync(persona);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    mensaje = "Errores de validación",
                    errores = validationResult.Errors.Select(e => new
                    {
                        campo = e.PropertyName,
                        mensaje = e.ErrorMessage
                    })
                });
            }

            var command = new CreatePersonaCommand(persona);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/personas/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<PersonaResponseDto>> Update(Guid id, [FromBody] UpdatePersonaDto persona)
        {
            var validationResult = await _updateValidator.ValidateAsync(persona);
            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    mensaje = "Errores de validación",
                    errores = validationResult.Errors.Select(e => new
                    {
                        campo = e.PropertyName,
                        mensaje = e.ErrorMessage
                    })
                });
            }

            var command = new UpdatePersonaCommand(id, persona);
            var result = await _mediator.Send(command);

            if (result == null)
                return NotFound(new { mensaje = "Persona no encontrada" });

            return Ok(result);
        }

        // DELETE: api/personas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeletePersonaCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(new { mensaje = "Persona no encontrada" });

            return NoContent();
        }
    }
}