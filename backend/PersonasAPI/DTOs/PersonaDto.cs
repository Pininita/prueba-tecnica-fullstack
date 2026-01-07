namespace PersonasAPI.DTOs
{
    public class CreatePersonaDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string? Telefono { get; set; }
    }

    public class UpdatePersonaDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string? Telefono { get; set; }
    }

    public class PersonaResponseDto
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