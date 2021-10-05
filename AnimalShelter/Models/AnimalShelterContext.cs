using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; } //update this

    public AnimalShelterContext(DbContextOptions options) : base(options) { }
  }
}