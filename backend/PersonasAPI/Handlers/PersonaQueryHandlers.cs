using MediatR;
using PersonasAPI.DTOs;
using PersonasAPI.Queries;
using PersonasAPI.Repositories;

namespace PersonasAPI.Handlers
{
    public class GetAllPersonasQueryHandler : IRequestHandler<GetAllPersonasQuery, List<PersonaResponseDto>>
    {
        private readonly IPersonaRepository _repository;

        public GetAllPersonasQueryHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PersonaResponseDto>> Handle(GetAllPersonasQuery request, CancellationToken cancellationToken)
        {
            var personas = await _repository.GetAllAsync();

            return personas.Select(p => new PersonaResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Correo = p.Correo,
                Documento = p.Documento,
                Telefono = p.Telefono,
                FechaCreacion = p.FechaCreacion
            }).ToList();
        }
    }

    public class GetPersonaByIdQueryHandler : IRequestHandler<GetPersonaByIdQuery, PersonaResponseDto?>
    {
        private readonly IPersonaRepository _repository;

        public GetPersonaByIdQueryHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<PersonaResponseDto?> Handle(GetPersonaByIdQuery request, CancellationToken cancellationToken)
        {
            var persona = await _repository.GetByIdAsync(request.Id);

            if (persona == null)
                return null;

            return new PersonaResponseDto
            {
                Id = persona.Id,
                Nombre = persona.Nombre,
                Apellido = persona.Apellido,
                Correo = persona.Correo,
                Documento = persona.Documento,
                Telefono = persona.Telefono,
                FechaCreacion = persona.FechaCreacion
            };
        }
    }

    public class SearchPersonasByNameQueryHandler : IRequestHandler<SearchPersonasByNameQuery, List<PersonaResponseDto>>
    {
        private readonly IPersonaRepository _repository;

        public SearchPersonasByNameQueryHandler(IPersonaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PersonaResponseDto>> Handle(SearchPersonasByNameQuery request, CancellationToken cancellationToken)
        {
            var personas = await _repository.SearchByNameAsync(request.Nombre);

            return personas.Select(p => new PersonaResponseDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Correo = p.Correo,
                Documento = p.Documento,
                Telefono = p.Telefono,
                FechaCreacion = p.FechaCreacion
            }).ToList();
        }
    }
}