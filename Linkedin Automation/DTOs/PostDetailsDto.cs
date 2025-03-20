using System.ComponentModel.DataAnnotations;

namespace Linkedin_Automation.DTOs
{
    public class PostDetailsDto
    {
        public Guid Id { get; set; }
        public string LinkedinProfileName { get; set; }
        public string PostUrl { get; set; }
        public string Postcomment { get; set; }

        public string Status { get; set; }
    }
}
