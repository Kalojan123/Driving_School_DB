using Driving_School_DB.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.DrivingInstructor
{
    public class DetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Categories Category { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}
