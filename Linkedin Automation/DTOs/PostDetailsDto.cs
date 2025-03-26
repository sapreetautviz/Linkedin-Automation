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

    public class PostRequestDto
    {
        public string PostUrl { get; set; }
        public string PostComment { get; set; }
    }

    public class PostResponseDto
    {
        public string PostUrl { get; set; }
    }

    public class KeywordDto
    {
        public string Keyword { get; set; }
    }

}
