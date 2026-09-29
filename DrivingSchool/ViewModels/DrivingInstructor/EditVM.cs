using Driving_School_DB.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.DrivingInstructor
{
    public class EditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(30, ErrorMessage = "Maximum 30 symbols!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required!")]
        [Phone(ErrorMessage = "Invalid phone number!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Category is required!")]
        [MaxLength(4, ErrorMessage = "Maximum 4 symbols!")]
        public Categories Category { get; set; }
    }
}
