using ExperticketPrueba.Api.Common;
using ExperticketPrueba.Api.Response;
using Microsoft.AspNetCore.Mvc;

namespace ExperticketPrueba.Api.Controllers.Base;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private readonly ILogger<BaseController> _logger;   
    
    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }

    private ErrorCodes ControlException(Exception e)
    {
        //TODO: Controlar el tipo de excepción para devolver un codigo u otro.
        return ErrorCodes.Unknown;
    }
    
    protected T HandleRequest<T>(Func<T> action) where T : BaseResponse, new()
    {
        try
        {
            return action();
        }
        catch (Exception e)
        {
            return new T
            {
                TimeStamp = DateTime.Now,
                ErrorList = new[]
                {
                    new BaseResponse.Error()
                    {
                        ErrorCode = (short)ControlException(e),
                        ErrorDescription = e.Message
                    }
                }
            };
        }
    }
}