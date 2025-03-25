using AutoMapper;
using Linkedin_Automation.DTOs;
using Linkedin_Automation.Models;

namespace Linkedin_Automation.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PostDetails, PostDetailsDto>().ReverseMap();
        }
    }
}
