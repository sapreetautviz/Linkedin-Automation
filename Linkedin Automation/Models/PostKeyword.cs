using System.ComponentModel.DataAnnotations;

namespace Linkedin_Automation.Models
{
    public class PostKeyword
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Keyword { get; set; }
        public string Status { get; set; }
    }
}
