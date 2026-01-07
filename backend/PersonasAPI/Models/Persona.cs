namespace PersonasAPI.Models
{
    public class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string? Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}