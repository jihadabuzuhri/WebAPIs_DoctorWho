using AutoMapper;
using DoctorWho.Db.Repository;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/Doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper) 
        {
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctor()
        {
            var doctors = await doctorRepository.GetAllDoctorsAsync();
            return Ok (mapper.Map<IEnumerable<DoctorDto>>(doctors));
        }


    }
}
