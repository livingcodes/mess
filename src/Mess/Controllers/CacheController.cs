using Mess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mess.Controllers
{
public class CacheController : Controller
{
    public CacheController(MemoryDb db) {
        this.db = db;
    }
    MemoryDb db = null;

    public IActionResult Index(bool populate = false, int removeId = 0, int updateId = 0) {
        if (populate)
            new PopulateDatabase(db).Execute();
        if (removeId > 0)
            db.Delete<Post>(removeId);
        if (updateId > 0) {
            var item = db.Select<Post>(updateId);
            item.Title = "Updated";
            db.Update<Post>(item);
        }
        return View(db.Select<Post>());
    }

    public void AddPost(Post post) {
        db.Insert(post);
    }
}
}
