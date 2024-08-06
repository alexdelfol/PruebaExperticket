using PruebaExperticket.Domain;

namespace ExperticketPrueba.Api.Response;

public class ClienteResponse : BaseResponse
{
    public IEnumerable<Cliente> Clientes { get; set; }
}