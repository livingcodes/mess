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
        
    }

    public List<T> Select<T>() {
        var key = getKey(typeof(T));
        var list = (List<T>)cache.Get(key);
        if (list == null)
            list = new List<T>();
        return list;
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