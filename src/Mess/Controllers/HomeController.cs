using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mess.Models;
using System.Dynamic;

namespace Mess.Controllers
{
public class HomeController : Controller
{
    // @Model.Message (strongly typed, intellisense)
    public IActionResult Index() {
        var posts = query();
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

    List<Post> query() {
        var posts = new List<Post>();
        posts.Add(new Post()
        {
            Id = 1,
            Title = "WebForms Fluent HTTP Request",
            Body = "Request.Header(\"user\", \"me\");",
            FriendlyUrlTitle = "webforms-fluent-http-request",
            PublishDate = new DateTime(2016, 12, 7)
        });
        posts.Add(new Post()
        {
            Id = 2,
            Title = "Pony Lang Land",
            Body = "pony ...",
            FriendlyUrlTitle = "pony-lang-land",
            PublishDate = new DateTime(2016, 12, 9)
        });
        posts.Add(new Post()
        {
            Id = 3,
            Title = "ASP.NET Core",
            Body = "Action Result Options",
            FriendlyUrlTitle = "aspnet-core",
            PublishDate = new DateTime(2016, 12, 10)
        });
        return posts;
    }
}
}