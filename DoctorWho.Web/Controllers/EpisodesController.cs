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


        [HttpPost("{episodeId}/enemy/{enemyId}")]
        public async Task<ActionResult> AddEnemyToEpisode(int episodeId, int enemyId)
        {
            var result = await episodeRepository.AddEnemyToEpisodeAsync(episodeId, enemyId);
            
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost("{episodeId}/companion/{companionId}")]
        public async Task<ActionResult> AddCompanionToEpisode(int episodeId, int companionId)
        {
            var result = await episodeRepository.AddCompanionToEpisodeAsync(episodeId, companionId);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }


}
