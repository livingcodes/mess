using Mess.Models;
using System;
using System.Collections.Generic;

namespace Mess.Services
{
public interface IPostService
{
    List<Post> Get();
}
public class PostService : IPostService
{
    public List<Post> Get() {
        return query();
    }

    List<Post> query() {
        var posts = new List<Post>();
        posts.Add(new Post() {
            Id = 1,
            Title = "WebForms Fluent HTTP Request",
            Body = "Request.Header(\"user\", \"me\");",
            FriendlyUrlTitle = "webforms-fluent-http-request",
            PublishDate = new DateTime(2016, 12, 7)
        });
        posts.Add(new Post() {
            Id = 2,
            Title = "Pony Lang Land",
            Body = "pony ...",
            FriendlyUrlTitle = "pony-lang-land",
            PublishDate = new DateTime(2016, 12, 9)
        });
        posts.Add(new Post() {
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