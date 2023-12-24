using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Server.Dto;
using Server.Models;

namespace Server.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto,Employee>();
            CreateMap<Activity,ActivityDto>();
            CreateMap<ActivityDto,Activity>();

        }
    }
}