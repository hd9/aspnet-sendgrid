using System.ComponentModel.DataAnnotations;

namespace AspNetSendGrid.Models
{
    public class NewsletterSignup
    {
        [StringLength(50, MinimumLength = 3)]
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }

        [EmailAddress]
        [Required(AllowEmptyStrings =false)]
        public string Email { get; set; }   
    }
}
