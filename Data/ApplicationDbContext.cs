using Microsoft.EntityFrameworkCore;
using SchedulingApp.Models;

namespace SchedulingApp.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Appointment> Appointments => Set<Appointment>();
  }
}
