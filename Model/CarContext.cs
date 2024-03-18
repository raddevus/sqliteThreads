namespace sqliteThreads.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class CarContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    
    public string DbPath { get; }

    public CarContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "car.db");
        Console.WriteLine(DbPath);
    }

}
