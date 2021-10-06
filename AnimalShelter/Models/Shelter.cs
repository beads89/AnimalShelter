using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Shelter
  {
    public Shelter()
    {
      this.Animals = new HashSet<Animal>();
    }

    public string Name {get; set;}
    public int ShelterId {get; set;}
    public virtual ICollection<Animal> Animals { get; set; }

    //constructor
  }
}