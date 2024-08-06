using PruebaExperticket.Domain;

namespace ExperticketPrueba.Api.Request;

public class ClienteGetRequest
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public DateTime? FechaNacimiento { get; set; }
}