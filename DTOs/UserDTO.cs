using System.ComponentModel.DataAnnotations;

namespace CrixusJa.DTOs
{
    public class UserDTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Username too long")]
        public string username { get; set; }
        

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string password { get; set; }

        public DateTime date { get; set; }

       
    }


}
