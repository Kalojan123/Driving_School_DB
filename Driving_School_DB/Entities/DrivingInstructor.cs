using Driving_School_DB.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_DB.Entities
{
    public class DrivingInstructor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Categories Category { get; set; }
        public DateTime RegisteredOn { get; set; }
        public bool IsGoneOff { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
