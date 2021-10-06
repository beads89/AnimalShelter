using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
  public class SheltersController : Controller
  {
    private readonly AnimalShelterContext _db;

    public SheltersController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Shelter> model = _db.Shelters.ToList();
      //Include(shelter => shelter.Shelter).
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Shelter shelter)
    {
      _db.Shelters.Add(shelter);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // public ActionResult Create()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult Create(Animal animal)
    // {
    //   //the animal used to be created here - constructor
    //   _db.Animals.Add(animal);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Details(int id)
    // {
    //   Animal animalToShow = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);

    //   return View(animalToShow);
    // }

    // public ActionResult Edit(int id)
    // {
    //   Animal animalToEdit = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    //   return View(animalToEdit);
    // }

    // [HttpPost]
    // public ActionResult Edit(Animal animal)
    // {
    //   _db.Entry(animal).State = EntityState.Modified;
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Delete(int id)
    // {
    //     Animal animalToDelete = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    //     return View(animalToDelete);
    // }

    // [HttpPost, ActionName("Delete")]
    // public ActionResult DeleteConfirmed(int id)
    // {
    //     Animal animalToDelete = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
    //     _db.Animals.Remove(animalToDelete);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index");
    // }
  }
}