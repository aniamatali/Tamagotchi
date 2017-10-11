using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet("/home")]
      public ActionResult PetView()
    {
      if(TamaUser.GetTama().GetFood() <= 0 || (TamaUser.GetTama().GetRest() <= 0) || (TamaUser.GetTama().GetAttention() <= 0))
      {
        return View("dead");
      }
      else
      {
        return View("pet", TamaUser.GetTama());
      }
    }

    [HttpPost("/feed")]
    public ActionResult FeedTama()
    {
      TamaUser.GetTama().GiveFood();
      return RedirectToAction("PetView");
    }

    [HttpPost("/sleep")]
    public ActionResult SleepTama()
    {
      TamaUser.GetTama().GiveRest();
      return RedirectToAction("PetView");
    }

    [HttpPost("/attention")]
    public ActionResult AttTama()
    {
      TamaUser.GetTama().GiveAttention();
      return RedirectToAction("PetView");
    }

    [HttpPost("/pass")]
    public ActionResult PassTama()
    {
      TamaUser.GetTama().PassTime();
      return RedirectToAction("PetView");
    }

    [HttpPost("/home")]
    public ActionResult PetName()
    {
      TamaUser newUser = new TamaUser(Request.Form["new-name"]);
      newUser.Save();
      return View("pet", newUser);
    }
  }
}
