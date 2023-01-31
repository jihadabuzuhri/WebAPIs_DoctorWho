using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Profiles
{
    public class EpisodeProfiler : Profile
    {
        public EpisodeProfiler() 
        {
            CreateMap<Episode,EpisodeDto >();
            CreateMap<EpisodeForCreationDto, Episode > ();
            CreateMap<EpisodeForUpdateDto, Episode >();

        }
    }
}
