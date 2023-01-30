using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repository
{
    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Episode>> GetAllEpisodesAsync()
        {
            return await _context.Episodes.ToListAsync();
        }

        public async Task AddEpisodeAsync(Episode episode)
        {
            await _context.Episodes.AddAsync(episode);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEpisodeAsync(Episode episode)
        {
            _context.Episodes.Update(episode);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteEpisodeAsync(int episodeId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);

            if (episode == null)
            {
                return false;
            }

            _context.Episodes.Remove(episode);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AddEnemyToEpisodeAsync(int episodeId, int enemyId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            var enemy = await _context.Enemies.FindAsync(enemyId);
            if (episode != null && enemy != null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy { EpisodeId = episodeId, EnemyId = enemyId });
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> AddCompanionToEpisodeAsync(int episodeId, int companionId)
        {
            var episode = await _context.Episodes.FindAsync(episodeId);
            var companion = await _context.Companions.FindAsync(companionId);
            if (episode != null && companion != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { EpisodeId = episodeId, CompanionId = companionId });
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }


    }




}
