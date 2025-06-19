using Microsoft.EntityFrameworkCore;

namespace UniversityApi.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options) { }

        public DbSet<StudentModel> Students => Set<StudentModel>();
        public DbSet<TeacherModel> Teachers => Set<TeacherModel>();
        public DbSet<SubjectModel> Subjects => Set<SubjectModel>();
        public DbSet<RoomModel> Rooms => Set<RoomModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubjectModel>()
                        .HasMany(s => s.Students)
                        .WithMany(s => s.Subjects);
        }
    }
}