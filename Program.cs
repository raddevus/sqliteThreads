// See https://aka.ms/new-console-template for more information
using sqliteThreads.Model;

Console.WriteLine("Hello, World!");

Car c = new Car{ThreadId="Main", Make="Ford", Model="Fairlane", Year=1968};

Console.WriteLine($"{c.ThreadId} : {c.Make} : {c.Model} : {c.Year}");

var db = new CarContext();

