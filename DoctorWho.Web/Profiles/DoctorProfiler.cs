using DoctorWho.Db;
using DoctorWho.Web.Models;
using AutoMapper;

namespace DoctorWho.Web.Profiles
{
    public class DoctorProfiler : Profile
    {
        public DoctorProfiler() {
 
            CreateMap<Doctor, DoctorDto>();
            
            //CreateMap<DoctorDto, Doctor > ();

//            CreateMap<Doctor, DoctorForUpsertionDto>();
            CreateMap< DoctorForUpsertionDto,Doctor>();




        }
    }
}
