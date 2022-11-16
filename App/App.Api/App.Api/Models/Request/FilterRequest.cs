using App.Common.Models;

namespace App.Api.Models.Request
{
    public class FilterRequest : RequestBase
    {
        public string Value { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
