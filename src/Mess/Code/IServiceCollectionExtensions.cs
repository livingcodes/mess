using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mess
{
public static class ISericeCollectionExtensions
{
    /// <summary>Add transient with class name that ends with ending argument 
    /// and implements interface with same name except I prefix.</summary>
    /// <param name="ending">Ending of the class name</param>
    public static void AddTransientEndingWith(
        this IServiceCollection collection,
        string ending
    ) {
        addTypeEndingWith(collection, ending, 
            (i, t) => collection.AddTransient(i, t));
    }

    /// <summary>Add scoped with class name that ends with ending argument 
    /// and implements interface with same name except I prefix.</summary>
    /// <param name="ending">Ending of the class name</param>
    public static void AddScopedEndingWith(
        this IServiceCollection collection,
        string ending
    ) {
        addTypeEndingWith(collection, ending,
            (i, t) => collection.AddScoped(i, t));
    }

    /// <summary>Add singleton with class name that ends with ending argument 
    /// and implements interface with same name except I prefix.</summary>
    /// <param name="ending">Ending of the class name</param>
    public static void AddSingletonEndingWith(
        this IServiceCollection collection,
        string ending
    ) {
        addTypeEndingWith(collection, ending,
            (i, t) => collection.AddSingleton(i, t));
    }

    static void addTypeEndingWith(
        this IServiceCollection service,
        string ending,
        Action<Type, Type> add
    ) {
        var assembly = System.Reflection.Assembly.GetEntryAssembly();
        var allTypes = assembly.GetTypes();
        List<Type> instances = new List<Type>();
        foreach (var type in allTypes) {
            if (!type.Name.EndsWith("Service"))
                continue;
            var interfaceType = allTypes.FirstOrDefault(t => t.Name == "I"+type.Name); //assembly.GetType("I"+type.Name);
            if (interfaceType is null)
                continue;
            add(interfaceType, type);
        }
    }
}
}