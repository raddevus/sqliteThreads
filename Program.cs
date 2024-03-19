// See https://aka.ms/new-console-template for more information
using sqliteThreads.Model;

const int INSERT_COUNT = 500;

Car c = new Car{ThreadId="Main", Make="Ford", Model="Fairlane", Year=1968};

Console.WriteLine($"{c.ThreadId} : {c.Make} : {c.Model} : {c.Year}");
Object lockOne = new Object();
Thread t = new Thread(() => WriteChevy("Secondary"));
Thread t2 = new Thread(() => WriteChevy("T2"));
Thread t3 = new Thread(()=>WriteFord("T3"));
Thread t4 = new Thread(()=>WriteChevy("T4"));
Thread t5 = new Thread(()=>WriteFord("T5"));
Thread t6 = new Thread(()=>WriteFord("T6"));
Thread t7 = new Thread(()=>WriteFord("T7"));
Thread t8 = new Thread(()=>WriteFord("T8"));
Thread t9 = new Thread(()=>WriteFord("T9"));
Thread t10 = new Thread(()=>WriteFord("T10"));
Thread t11 = new Thread(()=>WriteFord("T11"));
Thread t12 = new Thread(()=>WriteFord("T12"));


t.Start();
t2.Start();
t3.Start();
t4.Start();
t5.Start();
t6.Start();

t7.Start();
t8.Start();
t9.Start();
t10.Start();
t11.Start();
t12.Start();



WriteFord("Main");



async void WriteFord(String threadId){
    CarContext db = null;
    lock(lockOne){
       db = new CarContext();
    }
    Car c = new Car{ThreadId=threadId, Make="Ford", Model="Fairlane", Year=1968, Created=DateTime.Now};
    for (int i = 0; i<=INSERT_COUNT;i++){
        
        try{
            db.Add(c);
            db.SaveChanges();
        }
        catch(Exception ex){
            Console.WriteLine($"Error: ${threadId} : ${ex.InnerException.Message}");
            continue;
        }
        Thread.Sleep(5);
    }
}

void WriteChevy(string threadId){
    CarContext db = null;
    lock (lockOne){
        db = new CarContext();
    }
    Car c = new Car{ThreadId=threadId, Make="Chevy", Model="Corvette", Year=1962, Created=DateTime.Now};
    for (int i = 0; i<=INSERT_COUNT;i++){
        try{
        db.Add(c);
        db.SaveChanges();
        }
        catch(Exception ex){
            Console.WriteLine($"Error: ${threadId}");
            continue;
        }
        Thread.Sleep(5);
    }
}