using DeskBooker.Core.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace DeskBooker.Core.Domain
{
    public class DeskBookingBase
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DateInFuture]
        [DateWithoutTime]
        public DateTime Date { get; set; }
    }
}