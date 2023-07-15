using AutoMapper;
using EnrollmentManagement.DTO;
using EnrollmentManagement.Entity_Data;

namespace EnrollmentManagement.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Classes, ClassesDTO>().ReverseMap();
            CreateMap<Tuitions,TuitionsDTO>().ReverseMap();
            CreateMap<Permissions,PermissionDTO>().ReverseMap();
            CreateMap<Students,StudentsDTO>().ReverseMap();
        }
    }
}
