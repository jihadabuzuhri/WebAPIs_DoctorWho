
namespace DoctorWho.Db.Services
{
    public class OperationService
    {
        private readonly DoctorWhoCoreDbContext _context;

        public OperationService(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void AddEnemyToEpisode(int episodeId, int enemyId)
        {
            var episode = _context.Episodes.Find(episodeId);
            var enemy = _context.Enemies.Find(enemyId);
            if (episode != null && enemy !=null)
            {
                episode.EpisodeEnemies.Add(new EpisodeEnemy {EpisodeId=episodeId,EnemyId=enemyId });
                _context.SaveChanges();
            }
            
        }
        public void AddCompanionToEpisode(int episodeId, int companionId)
        {
            var episode = _context.Episodes.Find(episodeId);
            var companion = _context.Companions.Find(companionId);
            if (episode != null && companion != null)
            {
                episode.EpisodeCompanions.Add(new EpisodeCompanion { EpisodeId = episodeId, CompanionId=companionId });
                _context.SaveChanges();
            }
        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.ToList();
        }
        public Enemy GetEnemyById(int id)
        {
            return _context.Enemies.Find(id);
        }
        public Companion GetCompanionById(int id)
        {
            return _context.Companions.Find(id);
        }
    }
}
