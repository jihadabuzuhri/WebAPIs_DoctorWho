namespace DoctorWho.Db.Repository
{
    public class EnemyRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public EnemyRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void AddEnemy(Enemy enemy)
        {
            _context.Enemies.Add(enemy);
            _context.SaveChanges();
        }

        public void UpdateEnemy(Enemy enemy)
        {
            _context.Enemies.Update(enemy);
            _context.SaveChanges();
        }

        public void DeleteEnemy(int enemyId)
        {
            var enemy = _context.Enemies.Find(enemyId);
            _context.Enemies.Remove(enemy);
            _context.SaveChanges();
        }
    }




}
