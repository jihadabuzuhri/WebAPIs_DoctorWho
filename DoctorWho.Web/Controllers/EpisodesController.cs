using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorWho.Db;
using AutoMapper;
using DoctorWho.Db.Repository;
using DoctorWho.Web.Models;

namespace DoctorWho.Web.Controllers
{
    [Route("api/Episodes")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private IEpisodeRepository episodeRepository;
        private IMapper mapper;

        public EpisodesController(IEpisodeRepository episodeRepository, IMapper mapper)
        {
            this.episodeRepository = episodeRepository;
            this.mapper = mapper;
        }

        // GET: api/Episodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDto>>> GetEpisodes()
        {
            var episodes = await episodeRepository.GetAllEpisodesAsync();
            return Ok(mapper.Map<IEnumerable<EpisodeDto>>(episodes));
        }


        [HttpPost]
        public async Task<ActionResult> PostEpisode(EpisodeForCreationDto episodeForCreationDto)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */

            var episode = mapper.Map<Episode>(episodeForCreationDto);

            await episodeRepository.AddEpisodeAsync(episode);

            var episodeDto = mapper.Map<EpisodeDto>(episode);

            //return Ok(episodeDto);

            return Ok(episodeDto.EpisodeId);

        }
    }
}
