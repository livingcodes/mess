using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mess.Models;

namespace Mess.Controllers
{
public class HomeController : Controller
{
    public IActionResult Index() {
        var posts = query();
        return View(posts);
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

    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";

        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page.";

        return View();
    }

    public IActionResult Error()
    {
        return View();
    }
}
}
