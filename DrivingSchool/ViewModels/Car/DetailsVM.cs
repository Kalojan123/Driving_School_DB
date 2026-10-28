using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.Car
{
    public class DetailsVM
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Mileage { get; set; }
        public string DrivingInstructorName { get; set; }
    }
}
