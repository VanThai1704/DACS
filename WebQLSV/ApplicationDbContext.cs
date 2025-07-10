using Microsoft.EntityFrameworkCore;
using WebQLSV.Models;

namespace WebQLSV
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SinhVien> SinhViens { get; set; }
    }
} 