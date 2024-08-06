namespace ExperticketPrueba.Api.Response;

public class BaseResponse
{
    public bool Result { get; set; }
    public IEnumerable<Error>? ErrorList { get; set; }
    public DateTime TimeStamp { get; set; }

    public class Error
    {
        public short ErrorCode { get; set; }
        public string ErrorDescription { get; set; } = "";
    }
}