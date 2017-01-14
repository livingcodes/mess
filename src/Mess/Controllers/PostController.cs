using Mess.Models;
using Mess.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Mess.Controllers
{
public class PostController : Controller
{
    public PostController(IPostService service) {
        this.service = service;
    }
    IPostService service = null;

    [Route("api/[controller]s")]
    public List<Post> Get() {
        return service.Get();
    }

    [Route("api/[controller]/{id}")]
    public Post Get(int id) {
        return service.Get().FirstOrDefault(p => p.Id == id);
    }
}
}