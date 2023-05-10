using Microsoft.EntityFrameworkCore;
using PractiseStudentProject.Infrastructure.Data.Models;

namespace PractiseStudentProject.Infrastructure.Data
{
    public class PractiseStudentProjectContext : DbContext
    {
        public PractiseStudentProjectContext()
        {
            
        }
        public PractiseStudentProjectContext(DbContextOptions<PractiseStudentProjectContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
    }
}
