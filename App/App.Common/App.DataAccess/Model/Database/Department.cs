using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Models
{
    public class Department
    {
        #region Identifier
        [Key]
        public Guid InternalId { get; set; }
        [Required, MaxLength(15)]
        public string DepartmentId { get; set; } = string.Empty;
        #endregion

        #region Department Details
        [Required, MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid ManagerInternalId { get; set; }
        #endregion

        #region Common Entities
        [Required]
        public int Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
