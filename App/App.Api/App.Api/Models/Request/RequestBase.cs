using App.Common.Models;

namespace App.Api.Models.Request
{
    public class RequestBase
    {
        public ClientInformation client { get; set; }
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }
    }
}
