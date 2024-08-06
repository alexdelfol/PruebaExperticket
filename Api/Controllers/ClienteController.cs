using ExperticketPrueba.Api.Controllers.Base;
using ExperticketPrueba.Api.Request;
using ExperticketPrueba.Api.Response;
using Microsoft.AspNetCore.Mvc;
using PruebaExperticket.Domain;
using PruebaExperticket.Persistencia;

namespace ExperticketPrueba.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : BaseController
{
    private IRepository _repository;
    public ClienteController(ILogger<ClienteController> logger, IRepository repository):base(logger)
    {
        _repository = repository;
    }

    [HttpGet(Name = "GetByNationalDocumentIdentifier")]
    public ClienteResponse GetBasic(ClienteBasicGetRequest request)
    {
        return HandleRequest(() => new ClienteResponse
        {
            Clientes = new List<Cliente> { _repository.BuscarPorDni(request.Dni) },
            Result = true,
            TimeStamp = DateTime.Now
        });
    }

    [HttpGet(Name = "Get")]
    public ClienteResponse Get(ClienteGetRequest request)
    {
        IEnumerable<Cliente> clientes;
        if (request.Nombre is null && request.Apellido is null && request.FechaNacimiento is null)
        {
            clientes = _repository.ObtenerClientes();
        }
        else
        {
            clientes =
                _repository.BuscarPorNombreApellidosONacimiento(request.Nombre, request.Apellido, request.FechaNacimiento);
        }
        return HandleRequest(() => new ClienteResponse
        {
            Clientes = clientes,
            Result = true,
            TimeStamp = DateTime.Now
        });
    }
}   