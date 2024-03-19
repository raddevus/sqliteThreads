namespace sqliteThreads.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

public class CarContext : DbContext
{
    // The variable name must match the name of the table.
    public DbSet<Car> Vehicle { get; set; }
    
    public string DbPath { get; }

    public CarContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "car.db");
        Console.WriteLine(DbPath);

        SqliteConnection connection = new SqliteConnection($"Data Source={DbPath}");
        // ########### FYI THE DB is created when it is OPENED ########
        connection.Open();
        SqliteCommand command = connection.CreateCommand();
        FileInfo fi = new FileInfo(DbPath);
        if (fi.Length == 0){
            foreach (String tableCreate in allTableCreation){
                command.CommandText = tableCreate;
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine(connection.DataSource);
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

// [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    protected String [] allTableCreation = {
        @"CREATE TABLE vehicle
            (
            [ThreadId] NVARCHAR(30) NOT NULL check(length(ThreadId) <= 30),
            [Make] NVARCHAR(350)  NOT NULL check(length(Make) <= 350),
            [Model] NVARCHAR(350)  NOT NULL check(length(Model) <= 350),
            [Year] INTEGER NOT NULL default 0,
            [Created] NVARCHAR(30) default (datetime('now','localtime')) check(length(Created) <= 30)
            )"
    };

}
