using Microsoft.EntityFrameworkCore;
using RMV.DriverExaminer.Domain.Entities;

namespace RMV.DriverExaminer.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Sample> Sample { set; get; }
        public DbSet<ExamDetails> ExamDetails { set; get; }
    }
}
