using Driving_School_DB.Entities;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.Client
{
    public class DetailsVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DrivingInstructor { get; set; }
    }
}
