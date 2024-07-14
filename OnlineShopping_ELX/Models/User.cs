
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping_ELX.Models
{
    public class User
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage ="Password must be greater or equal to 8 characters")]
        public string Password { get; set; }
        public string? UserType { get; set; }

    }
}
