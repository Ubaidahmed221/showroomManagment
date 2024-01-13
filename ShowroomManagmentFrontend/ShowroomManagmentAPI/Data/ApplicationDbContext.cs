using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;


namespace ShowroomManagmentAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
    }
}
