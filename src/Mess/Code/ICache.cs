using System;

namespace Mess
{
public interface ICache
{
    object Get(string key);
    void Set(string key, object value, DateTime expiration);
    void Remove(string key);
}
}