namespace DoctorWho.Db.Repository
{
    public class EpisodeRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public EpisodeRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void AddEpisode(Episode episode)
        {
            _context.Episodes.Add(episode);
            _context.SaveChanges();
        }

        public void UpdateEpisode(Episode episode)
        {
            _context.Episodes.Update(episode);
            _context.SaveChanges();
        }

        public void DeleteEpisode(int episodeId)
        {
            var episode = _context.Episodes.Find(episodeId);
            _context.Episodes.Remove(episode);
            _context.SaveChanges();
        }
    }




}
