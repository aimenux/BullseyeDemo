using Bullseye;

namespace AppTwo;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var targets = new Targets();
        targets.Add(nameof(TargetTypes.Create), () => Console.WriteLine("Create infrastructure"));
        targets.Add(nameof(TargetTypes.Deploy), new[] { nameof(TargetTypes.Create) }, () => Console.WriteLine("Deploy web api"));
        targets.Add(nameof(TargetTypes.Start), new[] { nameof(TargetTypes.Deploy) }, () => Console.WriteLine("Start web api"));
        targets.Add(nameof(TargetTypes.Stop), new[] { nameof(TargetTypes.Start) }, () => Console.WriteLine("Stop web api"));
        targets.Add(nameof(TargetTypes.Destroy), new[] { nameof(TargetTypes.Stop) }, () => Console.WriteLine("Destroy infrastructure"));
        targets.Add(nameof(TargetTypes.Default), new[] { nameof(TargetTypes.Create), nameof(TargetTypes.Destroy) });
        await targets.RunAndExitAsync(args);
        Console.WriteLine("Press any key to exit !");
        Console.ReadKey();
    }
}