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

    [HttpGet]
    [Route("GetByNationalDocumentIdentifier")]
    public ClienteResponse GetBasic([FromQuery]ClienteBasicGetRequest request)
    {
        return HandleRequest(() => new ClienteResponse
        {
            Clientes = new List<Cliente> { _repository.BuscarPorDni(request.Dni) },
            Result = true,
            TimeStamp = DateTime.Now
        });
    }

    [HttpGet]
    public ClienteResponse Get([FromQuery]ClienteGetRequest request)
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

    [HttpPost]
    public BaseResponse Insert(Cliente cliente)
    {
        return HandleRequest(() => new BaseResponse
        {
            Result = _repository.AnyadirCliente(cliente),
            TimeStamp = DateTime.Now
        });
    }
    
    [HttpPut]
    public BaseResponse Update([FromQuery]string dni, [FromBody]Cliente cliente)
    {
        return HandleRequest(() => new BaseResponse
        {
            Result = _repository.ModificarCliente(dni, cliente),
            TimeStamp = DateTime.Now
        });
    }
    
    [HttpDelete]
    public BaseResponse Delete(string dni)
    {
        return HandleRequest(() => new BaseResponse
        {
            Result = _repository.EliminarCliente(dni),
            TimeStamp = DateTime.Now
        });
    }
}   