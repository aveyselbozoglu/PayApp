using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payer.Entities
{
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "{0} must be at least 5 characters"), Required(ErrorMessage = "{0} is required")]
        public string Username { get; set; }

        [MinLength(5, ErrorMessage = "{0} must be at least 5 characters"), Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
    }
}