using App.Common.Models;

namespace App.Api.Models.Request
{
    public class DepartmentRequest : RequestBase
    {
        public Department department { get; set; }
    }
}
