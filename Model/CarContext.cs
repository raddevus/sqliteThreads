namespace sqliteThreads.Model;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

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

    protected String [] allTableCreation = {
        @"CREATE TABLE vehicle
            ( [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Make] NVARCHAR(350)  NOT NULL check(length(Make) <= 350),
            [Model] NVARCHAR(350)  NOT NULL check(length(Model) <= 350),
            [Year] INTEGER NOT NULL default 0
            )"
    };

}
