using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving_School_DB.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        [Required]
        [MaxLength(20)]
        public string Color { get; set; }
        [Required]
        [Range(1885, 2026)]
        public int Year { get; set; }
        [Required]
        [MaxLength(10)]
        public string LicensePlate { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }
        public ICollection<DrivingInstructorsCars> DrivingInstructorsCars { get; set; } = new List<DrivingInstructorsCars>();        
    }
}
