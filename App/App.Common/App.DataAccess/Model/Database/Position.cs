using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Models
{
    public class Position
    {
        #region Identifier
        [Key]
        public Guid InternalId { get; set; }
        [Required, MaxLength(15)]
        public string PositionId { get; set; } = string.Empty;
        #endregion

        #region Position Details
        [Required, MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid DepartmentInternalId { get; set; }
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
