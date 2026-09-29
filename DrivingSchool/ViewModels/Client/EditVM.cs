using System.ComponentModel.DataAnnotations;

namespace DrivingSchool.ViewModels.Client
{
    public class EditVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(15, ErrorMessage = "Maximum 15 symbols!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(15, ErrorMessage = "Maximum 15 symbols!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email address is required!")]
        [EmailAddress(ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required!")]
        [Phone(ErrorMessage = "Invalid phone number!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please, choose driving instructor!")]
        public int DrivingInstructorId { get; set; }
    }
}
