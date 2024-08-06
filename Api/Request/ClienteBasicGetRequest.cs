using PruebaExperticket.Domain;

namespace ExperticketPrueba.Api.Request;

public class ClienteBasicGetRequest
{
    public required string Dni { get; set; }
}