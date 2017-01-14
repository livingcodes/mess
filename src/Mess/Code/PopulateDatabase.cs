using Mess.Models;
using System;
using System.Collections.Generic;

namespace Mess
{
public class PopulateDatabase
{
    public PopulateDatabase(MemoryDb db) { this.db = db; }
    MemoryDb db = null;

    public void Execute() {
        var posts = query();
        foreach (var post in posts)
            db.Insert(post);
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