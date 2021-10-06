using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


/*
add all the other properties - form, details
date - automatic setting - constructor - date input - placeholder set to current time as default
filter by 
  breed
  type
  date
  age
  name


*/

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.Include(animal => animal.Shelter).ToList();

      //call the OrderBy function, use ToList, put in a list done
      //add a switch statement - need an input, assign different sorted arrays based on that
      //get user input for how to sort it - index 
      // List<Animal> sorted = model.OrderBy(animal => animal.Age).ToList();
      //add logic here or make a static function in Animal class
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      //the animal used to be created here - constructor
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal animalToShow = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);

      return View(animalToShow);
    }

    public ActionResult Edit(int id)
    {
      Animal animalToEdit = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(animalToEdit);
    }

    [HttpPost]
    public ActionResult Edit(Animal animal)
    {
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Animal animalToDelete = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
        return View(animalToDelete);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Animal animalToDelete = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
        _db.Animals.Remove(animalToDelete);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}