using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevPulse.DTOs;
using DevPulse.Entities;
using DevPulse.Extensions;

namespace DevPulse.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Mapping from AppUser to MemberDto
            CreateMap<AppUser,MemberDto>();
            //Mapping from Job to JobDto
            CreateMap<Job,JobDto>()
                .ForMember(d => d.JobAge, o => o.MapFrom(s => s.StartDate.CalculateJobAge()));
        }
    }
}