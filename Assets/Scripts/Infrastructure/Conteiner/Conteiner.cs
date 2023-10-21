using System;
using System.Collections.Generic;


public class Conteiner
{
    private static Dictionary<Type, IService> _services = new();

    public static Conteiner instance;

    private Conteiner()
    {
    }

    public static void Initialaize()
    {
        if (instance == null)
            instance = new Conteiner();
    }

    public void AddSerivese<TService>(TService servise) where TService : IService
    {
        _services.Add(typeof(TService), servise);
    }

    public TService GetService<TService>()
    {
        return (TService)_services[typeof(TService)];
    }
}