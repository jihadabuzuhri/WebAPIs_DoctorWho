using AutoMapper;
using DoctorWho.Db;
using DoctorWho.Db.Repository;
using DoctorWho.Web.Models;
using DoctorWho.Web.Validators;
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

        [HttpPost("{doctorId}")]
        public async Task<ActionResult<DoctorDto>> UpsertDoctor(int doctorId, DoctorForUpsertionDto doctorForUpsertionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
            var validator = new DoctorForUpsertionValidator();
            var result = await validator.ValidateAsync(doctorForUpsertionDto);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            */

            var doctor = mapper.Map<Doctor>(doctorForUpsertionDto);
            
            var upsertedDoctor = await doctorRepository.UpsertDoctorAsync(doctorId,doctor);
            
            return Ok(mapper.Map<DoctorDto>(upsertedDoctor));

        }

        [HttpDelete("{doctorId}")]
        public async Task<ActionResult> DeleteDoctor(int doctorId)
        {
            var result = await doctorRepository.DeleteDoctorAsync(doctorId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
