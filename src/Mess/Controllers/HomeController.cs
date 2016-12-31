using Microsoft.AspNetCore.Mvc;
using Mess.Models;
using Mess.Services;
using System.Dynamic;

namespace Mess.Controllers
{
public class HomeController : Controller
{
    public HomeController(IPostService service) {
        this.service = service;
    }
    IPostService service;

    // @Model.Message (strongly typed, intellisense)
    public IActionResult Index() {
        var posts = service.Get();
        return View(posts);
    }

    // Model.Message (class, intellisense)
    public IActionResult ViewModelExample() {
        var model = new MessageViewModel() { Message = "Model" };
        return View(model);
    }

    // @ViewData["Message"] (dictionary)
    public IActionResult ViewDataExample() {
        ViewData["Message"] = "ViewData";
        return View();
    }

    // @ViewBag.Message (dynamic)
    public IActionResult ViewBagExample() {
        ViewBag.Message = "ViewBag";
        return View();
    }
    
    // @Model.Message (dynamic, expando)
    public IActionResult ExpandoExample() {
        dynamic model = new ExpandoObject();
        model.Message = "Expando";
        return View(model);

        // doesn't work (runtime exception)
        //dynamic model = new { Message = "Dynamic" };
        //return View(model);
    }

    public IActionResult Error() {
        return View();
    }
}
}