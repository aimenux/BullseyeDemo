using System;
using static Bullseye.Targets;

namespace AppOne;

public static class Program
{
    public static void Main(string[] args)
    {
        Target(nameof(TargetTypes.Create), () => Console.WriteLine("Create infrastructure"));
        Target(nameof(TargetTypes.Deploy), DependsOn(nameof(TargetTypes.Create)), () => Console.WriteLine("Deploy web api"));
        Target(nameof(TargetTypes.Start), DependsOn(nameof(TargetTypes.Deploy)), () => Console.WriteLine("Start web api"));
        Target(nameof(TargetTypes.Stop), DependsOn(nameof(TargetTypes.Start)), () => Console.WriteLine("Stop web api"));
        Target(nameof(TargetTypes.Destroy), DependsOn(nameof(TargetTypes.Stop)), () => Console.WriteLine("Destroy infrastructure"));
        Target(nameof(TargetTypes.Default), DependsOn(nameof(TargetTypes.Create), nameof(TargetTypes.Destroy)));
        RunTargetsWithoutExiting(args);
        Console.WriteLine("Press any key to exit !");
        Console.ReadKey();
    }

    public enum TargetTypes
    {
        Create,
        Deploy,
        Start,
        Stop,
        Destroy,
        Default
    }
}