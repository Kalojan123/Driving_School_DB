using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.Car
{
    public class EditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Brand is required!")]
        [MaxLength(50, ErrorMessage = "Maximum 50 symbols!")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Model is required!")]
        [MaxLength(50, ErrorMessage = "Maximum 50 symbols!")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Color is required!")]
        [MaxLength(20, ErrorMessage = "Maximum 20 symbols!")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Year is required!")]
        [Range(1885, 2026, ErrorMessage = "Year must be between 1885 and 2026!")]
        public int Year { get; set; }
        [Required(ErrorMessage = "License plate is required!")]
        [MaxLength(10, ErrorMessage = "Maximum 10 symbols!")]
        public string LicensePlate { get; set; }
        [Required(ErrorMessage = "Mileage is required!")]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage must be between 0 and 2,147,483,647!")]
        public int Mileage { get; set; }
        [Required(ErrorMessage = "Please, choose driving instructor!")]
        public List<int> DrivingInstructorIds { get; set; } = new List<int>();
    }
}
