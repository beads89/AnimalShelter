using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
  public class HomeController : Controller
  {
    // [HttpGet("/")]
    public ActionResult Index() { 
      ViewBag.MyFavoriteColor = "green";
      return View(); 
    }
  }
}