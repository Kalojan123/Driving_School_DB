using Driving_School_DB.Enums;

namespace DrivingSchool.ViewModels.DrivingInstructor
{
    public class IndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Categories Category { get; set; }
    }
}
