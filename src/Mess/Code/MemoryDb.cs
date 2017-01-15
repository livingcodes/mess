using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mess
{
public class MemoryDb
{
    public MemoryDb(ICache cache) {
        this.cache = cache;
    }
    ICache cache;

    public void Insert<T>(T item) {
        var key = getKey(typeof(T));
        var list = (List<T>)cache.Get(key);
        if (list == null)
            list = new List<T>();
        list.Add(item);
        cache.Set(key, list, DateTime.Now.AddDays(1));
    }

    public void Update<T>(T item) {
        var key = getKey(typeof(T));
        var list = (List<T>)cache.Get(key);
        var existingItem = list.FirstOrDefault(i => ((int)i.GetType().GetField("Id").GetValue(i)) == ((int)item.GetType().GetField("Id").GetValue(item)));
        if (existingItem == null)
            throw new Exception("Cannot update. Item not found.");
        var index = list.IndexOf(existingItem);
        list[index] = item;
        cache.Set(key, list, DateTime.Now.AddDays(1));
    }

    public List<T> Select<T>() {
        var key = getKey(typeof(T));
        var list = (List<T>)cache.Get(key);
        if (list == null)
            list = new List<T>();
        return list;
    }

    public T Select<T>(int id) {
        var list = Select<T>();
        var item = list.FirstOrDefault(i => ((int)i.GetType().GetField("Id").GetValue(i)) == id);
        return item;
    }

    public void Delete<T>(int id) {
        var key = getKey(typeof(T));
        var list = (List<T>)cache.Get(key);
        if (list == null)
            list = new List<T>();
        var item = list.FirstOrDefault(i => ((int)i.GetType().GetField("Id").GetValue(i)) == id);
        list.Remove(item);
        cache.Set(key, list, DateTime.Now.AddDays(1));
    }

    string getKey(Type type) {
        return type.Name;
    }
}
}