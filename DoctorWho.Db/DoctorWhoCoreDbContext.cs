using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class DoctorWhoCoreDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
        public DbSet<viewEpisodes> viewEpisodes { get; set; }
        public string CallFnCompanions(int Id) => throw new NotSupportedException();
        public string CallFnEnemies(int Id) => throw new NotSupportedException();



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost;Database=DoctorWhoCore;Trusted_Connection=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).IsRequired();
            modelBuilder.Entity<Author>().Property(a => a.AuthorName).HasColumnType("varchar(400)");

            modelBuilder.Entity<Companion>().HasKey(c => c.CompanionId);
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).IsRequired();
            modelBuilder.Entity<Companion>().Property(c => c.CompanionName).HasColumnType("varchar(400)");

            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.DoctorName).HasColumnType("varchar(400)");
            modelBuilder.Entity<Doctor>().Property(d => d.BirthDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.FirstEpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Doctor>().Property(d => d.LastEpisodeDate).HasDefaultValueSql("NULL");

            modelBuilder.Entity<Enemy>().HasKey(e => e.EnemyId);
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).IsRequired();
            modelBuilder.Entity<Enemy>().Property(e => e.EnemyName).HasColumnType("varchar(400)");
            modelBuilder.Entity<Enemy>().Property(e => e.Description).HasDefaultValueSql("NULL");

            modelBuilder.Entity<Episode>().HasKey(e => e.EpisodeId);
            modelBuilder.Entity<Episode>().Property(e => e.SeriesNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeNumber).HasDefaultValueSql("0");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).IsRequired();
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeType).HasColumnType("varchar(400)");
            modelBuilder.Entity<Episode>().Property(e => e.Title).HasColumnType("varchar(400)");
            modelBuilder.Entity<Episode>().Property(e => e.EpisodeDate).HasDefaultValueSql("NULL");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasColumnType("varchar(400)");
            modelBuilder.Entity<Episode>().Property(e => e.Notes).HasDefaultValueSql("NULL");



            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorNumber = 1, DoctorName = "William Hartnell", BirthDate = new DateTime(1908, 01, 08), FirstEpisodeDate = new DateTime(1963, 11, 23), LastEpisodeDate = new DateTime(1966, 07, 22) },
                new Doctor { DoctorId = 2, DoctorNumber = 2, DoctorName = "Patrick Troughton", BirthDate = new DateTime(1920, 05, 25), FirstEpisodeDate = new DateTime(1966, 10, 29), LastEpisodeDate = new DateTime(1969, 06, 21) },
                new Doctor { DoctorId = 3, DoctorNumber = 3, DoctorName = "Jon Pertwee", BirthDate = new DateTime(1919, 07, 07), FirstEpisodeDate = new DateTime(1970, 01, 03), LastEpisodeDate = new DateTime(1974, 06, 08) },
                new Doctor { DoctorId = 4, DoctorNumber = 4, DoctorName = "Tom Baker", BirthDate = new DateTime(1934, 01, 20), FirstEpisodeDate = new DateTime(1974, 12, 28), LastEpisodeDate = new DateTime(1981, 03, 21) },
                new Doctor { DoctorId = 5, DoctorNumber = 5, DoctorName = "Peter Davison", BirthDate = new DateTime(1951, 04, 13), FirstEpisodeDate = new DateTime(1982, 03, 05), LastEpisodeDate = new DateTime(1984, 12, 29) }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Sydney Newman" },
                new Author { AuthorId = 2, AuthorName = "Donald Wilson" },
                new Author { AuthorId = 3, AuthorName = "Brian Hayles" },
                new Author { AuthorId = 4, AuthorName = "Robert Holmes" },
                new Author { AuthorId = 5, AuthorName = "Terrance Dicks" }
            );

            modelBuilder.Entity<Companion>().HasData(
                new Companion { CompanionId = 1, CompanionName = "Susan Foreman", WhoPlayed = "Carole Ann Ford" },
                new Companion { CompanionId = 2, CompanionName = "Vicki", WhoPlayed = "Maureen O'Brien" },
                new Companion { CompanionId = 3, CompanionName = "Steven Taylor", WhoPlayed = "Peter Purves" },
                new Companion { CompanionId = 4, CompanionName = "Katarina", WhoPlayed = "Adrienne Hill" },
                new Companion { CompanionId = 5, CompanionName = "Ace", WhoPlayed = "Sophie Aldred" }
            );

            modelBuilder.Entity<Episode>().HasData(
                new Episode { EpisodeId = 1, SeriesNumber = 1, EpisodeNumber = 1, EpisodeType = "TV", Title = "An Unearthly Child", EpisodeDate = new DateTime(1963, 11, 23), AuthorId = 1, DoctorId = 1, Notes = "First episode of Doctor Who" },
                new Episode { EpisodeId = 2, SeriesNumber = 1, EpisodeNumber = 2, EpisodeType = "TV", Title = "The Daleks", EpisodeDate = new DateTime(1963, 12, 21), AuthorId = 2, DoctorId = 1, Notes = "First appearance of the Daleks" },
                new Episode { EpisodeId = 3, SeriesNumber = 2, EpisodeNumber = 1, EpisodeType = "TV", Title = "The Power of the Daleks", EpisodeDate = new DateTime(1966, 11, 5), AuthorId = 3, DoctorId = 2, Notes = "" },
                new Episode { EpisodeId = 4, SeriesNumber = 3, EpisodeNumber = 1, EpisodeType = "TV", Title = "Spearhead from Space", EpisodeDate = new DateTime(1970, 1, 3), AuthorId = 4, DoctorId = 3, Notes = "" },
                new Episode { EpisodeId = 5, SeriesNumber = 4, EpisodeNumber = 1, EpisodeType = "TV", Title = "Robot", EpisodeDate = new DateTime(1974, 12, 28), AuthorId = 5, DoctorId = 4, Notes = "" }
                );


            modelBuilder.Entity<EpisodeCompanion>().HasData(
                new EpisodeCompanion { EpisodeCompanionId = 1, EpisodeId = 1, CompanionId = 1 },
                new EpisodeCompanion { EpisodeCompanionId = 2, EpisodeId = 2, CompanionId = 1 },
                new EpisodeCompanion { EpisodeCompanionId = 3, EpisodeId = 3, CompanionId = 2 },
                new EpisodeCompanion { EpisodeCompanionId = 4, EpisodeId = 4, CompanionId = 3 },
                new EpisodeCompanion { EpisodeCompanionId = 5, EpisodeId = 5, CompanionId = 4 }
            );

            modelBuilder.Entity<Enemy>().HasData(
                new Enemy { EnemyId = 1, EnemyName = "Daleks", Description = "A race of mutants from the planet Skaro" },
                new Enemy { EnemyId = 2, EnemyName = "Cybermen", Description = "A race of cybernetically augmented humanoids" },
                new Enemy { EnemyId = 3, EnemyName = "Sontarans", Description = "A warrior race of clones" },
                new Enemy { EnemyId = 4, EnemyName = "Silurians", Description = "An intelligent reptilian species" },
                new Enemy { EnemyId = 5, EnemyName = "Weeping Angels", Description = "A species of quantum-locked humanoids" }
            );

            modelBuilder.Entity<EpisodeEnemy>().HasData(
                new EpisodeEnemy { EpisodeEnemyId = 1, EpisodeId = 1, EnemyId = 1 },
                new EpisodeEnemy { EpisodeEnemyId = 2, EpisodeId = 2, EnemyId = 1 },
                new EpisodeEnemy { EpisodeEnemyId = 3, EpisodeId = 3, EnemyId = 2 },
                new EpisodeEnemy { EpisodeEnemyId = 4, EpisodeId = 4, EnemyId = 3 },
                new EpisodeEnemy { EpisodeEnemyId = 5, EpisodeId = 5, EnemyId = 4 }
            );



            modelBuilder.Entity<viewEpisodes>().HasNoKey().ToView("viewEpisodes");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(CallFnCompanions), new[] { typeof(int) }))
            .HasName("fnCompanions");

            modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext).GetMethod(nameof(CallFnEnemies), new[] { typeof(int) }))
            .HasName("fnEnemies");


        }

    }
}