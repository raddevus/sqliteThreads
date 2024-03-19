namespace sqliteThreads.Model;
public class Car{

    public Int64 Id{get;set;}
    public string ThreadId{get;set;}
    public string Make{get;set;}
    public string Model{get;set;}
    public int Year{get;set;}
    public DateTime Created {get;set;}
}