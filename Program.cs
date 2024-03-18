// See https://aka.ms/new-console-template for more information
using sqliteThreads.Model;

Console.WriteLine("Hello, World!");

Car c = new Car{Make="Ford", Model="Fairlane", Year=1968};

Console.WriteLine($"{c.Make} : {c.Model} : {c.Year}");

var db = new CarContext();

