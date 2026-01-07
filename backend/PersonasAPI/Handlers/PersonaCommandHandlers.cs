using MediatR;
using PersonasAPI.Commands;
using PersonasAPI.DTOs;
using PersonasAPI.Models;
using PersonasAPI.Repositories;

namespace PersonasAPI.Handlers
{
    public class CreatePersonaCommandHandler : IRequestHandler<CreatePersonaCommand, PersonaResponseDto>
    {
        private readonly IPersonaRepository _repository;

        public CreatePersonaCommandHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonaResponseDto> Handle(CreatePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = new Persona
            {
                Nombre = request.Persona.Nombre,
                Apellido = request.Persona.Apellido,
                Correo = request.Persona.Correo,
                Documento = request.Persona.Documento,
                Telefono = request.Persona.Telefono
            };

            var created = await _repository.CreateAsync(persona);

            return new PersonaResponseDto
            {
                Id = created.Id,
                Nombre = created.Nombre,
                Apellido = created.Apellido,
                Correo = created.Correo,
                Documento = created.Documento,
                Telefono = created.Telefono,
                FechaCreacion = created.FechaCreacion
            };
        }
    }

    public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, PersonaResponseDto?>
    {
        private readonly IPersonaRepository _repository;

        public UpdatePersonaCommandHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonaResponseDto?> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            var persona = new Persona
            {
                Nombre = request.Persona.Nombre,
                Apellido = request.Persona.Apellido,
                Correo = request.Persona.Correo,
                Documento = request.Persona.Documento,
                Telefono = request.Persona.Telefono
            };

            var updated = await _repository.UpdateAsync(request.Id, persona);

            if (updated == null)
                return null;

            return new PersonaResponseDto
            {
                Id = updated.Id,
                Nombre = updated.Nombre,
                Apellido = updated.Apellido,
                Correo = updated.Correo,
                Documento = updated.Documento,
                Telefono = updated.Telefono,
                FechaCreacion = updated.FechaCreacion
            };
        }
    }

    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, bool>
    {
        private readonly IPersonaRepository _repository;

        public DeletePersonaCommandHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}