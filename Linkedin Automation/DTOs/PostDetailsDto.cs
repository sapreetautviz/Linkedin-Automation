using System.ComponentModel.DataAnnotations;

namespace Linkedin_Automation.DTOs
{
    public class PostDetailsDto
    {
        public string LinkedinProfileName { get; set; }
        public string PostUrl { get; set; }
        public string Postcomment { get; set; }
    }

    public class logsDto
    {
        public string PostUrl { get; set; }
    }

}
