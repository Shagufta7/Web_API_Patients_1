using Web_API_Patients;
using Microsoft.EntityFrameworkCore;
using Web_API_Patients.Data.Entities;

namespace Web_API_Patients.Data


{
    public class MyDatabaseDbContext : DbContext
    {
       

        public MyDatabaseDbContext(DbContextOptions<MyDatabaseDbContext> options) : base(options)
        {

        }

        public DbSet<Patients> Patients { get; set; }
    }
}
