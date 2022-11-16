using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Models
{
    public class Request
    {
        [Key, MaxLength(15)]
        public string RequestId { get; set; } = string.Empty;

        [Required, MaxLength(5)]
        public string FunctionId { get; set; } = string.Empty;
        [Required, MaxLength(2)]
        public string Status { get; set; } = string.Empty;
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
