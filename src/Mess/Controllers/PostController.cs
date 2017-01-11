using Mess.Models;
using Mess.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Mess.Controllers
{
public class PostController : Controller
{
    public PostController(IPostService service) {
        this.service = service;
    }
    IPostService service = null;

    [Route("api/posts")]
    public List<Post> Get() {
        return service.Get();
    }
}
}