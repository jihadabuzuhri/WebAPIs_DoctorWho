namespace DoctorWho.Db.Repository
{
    public interface IEpisodeRepository
    {
        Task<bool> AddCompanionToEpisodeAsync(int episodeId, int companionId);
        Task<bool> AddEnemyToEpisodeAsync(int episodeId, int enemyId);
        Task AddEpisodeAsync(Episode episode);
        Task<bool> DeleteEpisodeAsync(int episodeId);
        Task<List<Episode>> GetAllEpisodesAsync();
        Task UpdateEpisodeAsync(Episode episode);
    }
}