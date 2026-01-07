using PersonasAPI.Models;

namespace PersonasAPI.Repositories
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(Guid id);
        Task<List<Persona>> SearchByNameAsync(string nombre);
        Task<Persona> CreateAsync(Persona persona);
        Task<Persona?> UpdateAsync(Guid id, Persona persona);
        Task<bool> DeleteAsync(Guid id);
    }

    public class PersonaRepository : IPersonaRepository
    {
        private readonly List<Persona> _personas = new();

        public Task<List<Persona>> GetAllAsync()
        {
            return Task.FromResult(_personas.ToList());
        }

        public Task<Persona?> GetByIdAsync(Guid id)
        {
            var persona = _personas.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(persona);
        }

        public Task<List<Persona>> SearchByNameAsync(string nombre)
        {
            var resultados = _personas
                .Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase) ||
                           p.Apellido.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
            return Task.FromResult(resultados);
        }

        public Task<Persona> CreateAsync(Persona persona)
        {
            persona.Id = Guid.NewGuid();
            persona.FechaCreacion = DateTime.UtcNow;
            _personas.Add(persona);
            return Task.FromResult(persona);
        }

        public Task<Persona?> UpdateAsync(Guid id, Persona persona)
        {
            var existingPersona = _personas.FirstOrDefault(p => p.Id == id);
            if (existingPersona == null)
                return Task.FromResult<Persona?>(null);

            existingPersona.Nombre = persona.Nombre;
            existingPersona.Apellido = persona.Apellido;
            existingPersona.Correo = persona.Correo;
            existingPersona.Documento = persona.Documento;
            existingPersona.Telefono = persona.Telefono;

            return Task.FromResult<Persona?>(existingPersona);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var persona = _personas.FirstOrDefault(p => p.Id == id);
            if (persona == null)
                return Task.FromResult(false);

            _personas.Remove(persona);
            return Task.FromResult(true);
        }
    }
}