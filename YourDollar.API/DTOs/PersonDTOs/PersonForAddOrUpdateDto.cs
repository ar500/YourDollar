using System.ComponentModel.DataAnnotations;

namespace YourDollar.API.DTOs.PersonDTOs
{
    public class PersonForAddOrUpdateDto
    {
        [Required(ErrorMessage = "Please provide your first name.")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide your last name.")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide your email address")]
        [EmailAddress(ErrorMessage = "Your email address is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide your phone number.")]
        [Phone(ErrorMessage = "Your phone number is not valid.")]
        public string PhoneNumber { get; set; }
    }
}
