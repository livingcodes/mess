using Mess.Models;
using System.Collections.Generic;

namespace Mess.Services
{
public interface IPostService
{
    List<Post> Get();
}
public class PostService : IPostService
{
    public PostService(MemoryDb db) { this.db = db; }
    MemoryDb db = null;

    public List<Post> Get() {
        return db.Select<Post>();
    }
}
}