using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.Models
{
    public class Employee
    {
        #region Identifier
        [Key]
        public Guid InternalId { get; set; }
        [Required, MaxLength(15)]
        public string EmployeeId { get; set; } = string.Empty;
        #endregion

        #region Personal Details
        [Required, MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(20)]
        public string? MiddleName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
        [Required, MaxLength(6)]
        public string Gender { get; set; } = string.Empty;
        [Required, Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }
        [Required, MaxLength(100)]
        public string Birthplace { get; set; } = string.Empty;
        [Required, MaxLength(10)]
        public string CivilStatus { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string Citizenship { get; set; } = string.Empty;
        #endregion

        #region Contact Details
        [Required, MaxLength(15)]
        public string ContactNo { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? EmailAddress { get; set; }
        #endregion

        #region Address Details
        [Required, MaxLength(50)]
        public string HomeDetails { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Street { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Village { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Barangay { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string City { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string ZipCode { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Province { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Country { get; set; } = string.Empty;
        #endregion

        #region Spouse Details
        [MaxLength(60)]
        public string? SpouseName { get; set; }
        [MaxLength(15)]
        public string? SpouseContactNo { get; set; }
        [MaxLength(50)]
        public string? SpouseEmailAddress { get; set; }
        [MaxLength(100)]
        public string? SpouseAddress { get; set; }
        #endregion

        #region Emergency PTC Details
        [Required, MaxLength(60)]
        public string EPTCName { get; set; } = string.Empty;
        [Required, MaxLength(15)]
        public string EPTCContactNo { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string EPTCEmailAddress { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string EPTCRelation { get; set; } = string.Empty;
        [Required, MaxLength(100)]
        public string EPTCAddress { get; set; } = string.Empty;
        #endregion

        #region Employment Details
        [Required]
        public Guid PositionInternalId { get; set; }
        [Required, MaxLength(10)]
        public string Type { get; set; } = string.Empty;
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
