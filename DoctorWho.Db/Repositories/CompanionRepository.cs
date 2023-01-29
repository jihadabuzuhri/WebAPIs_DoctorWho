namespace DoctorWho.Db.Repository
{
    public class CompanionRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public CompanionRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void AddCompanion(Companion companion)
        {
            _context.Companions.Add(companion);
            _context.SaveChanges();
        }

        public void UpdateCompanion(Companion companion)
        {
            _context.Companions.Update(companion);
            _context.SaveChanges();
        }

        public void DeleteCompanion(int companionId)
        {
            var companion = _context.Companions.Find(companionId);
            _context.Companions.Remove(companion);
            _context.SaveChanges();
        }
    }




}
