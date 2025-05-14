using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    private static Dictionary<Type, object> _container = new();

    public static void Register<T>(T value)
    {
        _container[typeof(T)] = value;
    }

    public static T Get<T>()
    {
        return (T)_container[typeof(T)];
    }
}