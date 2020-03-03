using System;
using static Bullseye.Targets;

namespace App
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Target(nameof(Targets.Create), () => Console.WriteLine("Create infra"));
            Target(nameof(Targets.Deploy), DependsOn(nameof(Targets.Create)), () => Console.WriteLine("Deploy api"));
            Target(nameof(Targets.Start), DependsOn(nameof(Targets.Deploy)), () => Console.WriteLine("Start api"));
            Target(nameof(Targets.Stop), DependsOn(nameof(Targets.Start)), () => Console.WriteLine("Stop api"));
            Target(nameof(Targets.Destroy), DependsOn(nameof(Targets.Stop)), () => Console.WriteLine("Destroy infra"));
            Target(nameof(Targets.Default), DependsOn(nameof(Targets.Create), nameof(Targets.Destroy)));
            RunTargetsWithoutExiting(args);
            Console.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }

        public enum Targets
        {
            Create,
            Deploy,
            Start,
            Stop,
            Destroy,
            Default
        }
    }
}
