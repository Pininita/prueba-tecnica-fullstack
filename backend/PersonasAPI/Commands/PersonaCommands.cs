using MediatR;
using PersonasAPI.DTOs;

namespace PersonasAPI.Commands
{
    // Crear Persona
    public class CreatePersonaCommand : IRequest<PersonaResponseDto>
    {
        public CreatePersonaDto Persona { get; set; }

        public CreatePersonaCommand(CreatePersonaDto persona)
        {
            Persona = persona;
        }
    }

    // Actualizar Persona
    public class UpdatePersonaCommand : IRequest<PersonaResponseDto?>
    {
        public Guid Id { get; set; }
        public UpdatePersonaDto Persona { get; set; }

        public UpdatePersonaCommand(Guid id, UpdatePersonaDto persona)
        {
            Id = id;
            Persona = persona;
        }
    }

    // Eliminar Persona
    public class DeletePersonaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeletePersonaCommand(Guid id)
        {
            Id = id;
        }
    }
}