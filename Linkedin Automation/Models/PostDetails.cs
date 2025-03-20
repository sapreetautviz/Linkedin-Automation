using System.ComponentModel.DataAnnotations;

namespace Linkedin_Automation.Models
{
    public class PostDetails
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string LinkedinProfileName { get; set; }
        [Required]
        public string PostUrl { get; set; }
        [Required]
        public string Postcomment { get; set; }

        public string Status { get; set; }
    }
}
