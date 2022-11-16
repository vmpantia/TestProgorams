using App.Common.Models;

namespace App.Api.Models.Request
{
    public class PositionRequest : RequestBase
    {
        public Position position { get; set; }
    }
}
