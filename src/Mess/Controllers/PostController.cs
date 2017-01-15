using Mess.Models;
using Mess.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Mess.Controllers
{
public class PostController : Controller
{
    public PostController(MemoryDb db) {
        this.db = db;
    }
    MemoryDb db = null;

    [Route("api/[controller]s")]
    public List<Post> Get() {
        return db.Select<Post>();
    }

    [Route("api/[controller]/{id}")]
    public Post Get(int id) {
        return db.Select<Post>(id);
    }
}
}