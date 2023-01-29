namespace DoctorWho.Db.Repository
{
    public class AuthorRepository
    {
        private readonly DoctorWhoCoreDbContext _context;

        public AuthorRepository(DoctorWhoCoreDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            var author = _context.Authors.Find(authorId);
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }


}
