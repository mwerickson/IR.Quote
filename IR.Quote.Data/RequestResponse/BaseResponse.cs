namespace IR.Quote.Data.RequestResponse
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public string DetailedMessage { get; set; }
    }
}