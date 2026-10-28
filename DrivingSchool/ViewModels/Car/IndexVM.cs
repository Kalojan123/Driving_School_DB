using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.Car
{
    public class IndexVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        [Display(Name = "Driving Instructor")]
        public string DrivingInstructorName { get; set; } = string.Empty;
    }
}
