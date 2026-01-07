using MediatR;
using PersonasAPI.DTOs;

namespace PersonasAPI.Queries
{
    // Obtener todas las personas
    public class GetAllPersonasQuery : IRequest<List<PersonaResponseDto>>
    {
    }

    // Obtener persona por ID
    public class GetPersonaByIdQuery : IRequest<PersonaResponseDto?>
    {
        public Guid Id { get; set; }

        public GetPersonaByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    // Buscar personas por nombre
    public class SearchPersonasByNameQuery : IRequest<List<PersonaResponseDto>>
    {
        public string Nombre { get; set; }

        public SearchPersonasByNameQuery(string nombre)
        {
            Nombre = nombre;
        }
    }
}