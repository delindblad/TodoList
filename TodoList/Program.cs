using System.Text.Json;
using System.Text.Json.Serialization;
using MenuPageKit;
using Microsoft.Extensions.Logging;

namespace TodoList;

public static class Program
{
    static TodoManager manager;

    static void Main(string[] args)
    {
        //Create logger
        ILogger logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger("Main");
        //Init manager
        InitManager();
        Run();
        
        



    }
    
    public static void Run()
    {
        var root = new RootPage("Todo List Manager", manager);
        root.AddChildPage(new ShowTasksPage("Show tasks", root, manager));
        root.AddChildPage(new AddTaskPage("Add task", root, manager));
        root.AddChildPage(new LoadPage("Load from file", root, manager));
        root.AddChildPage(new ExportPage("Export to file", root, manager));
        //logger.LogInformation("Added simple child pages");
        AbstractMenuPage? context = root;
        while (true)
        {
            context = context.Run();
            if (context == null!)
            {
                return;
            }
        }

        AbstractMenuPage? p = root.Run();
        if (p == null)
        {
            return;
        }
        else
        {
            p.Run().Run();
        }
    }


    public static void Test()
    {

        manager.AddItem("Cleaning", TaskStatus.InProgress, DateTime.Parse("2026-10-01"));
        manager.AddItem("Laundry", TaskStatus.Done, DateTime.Parse("2026-11-07"));
        manager.AddItem("Groceries", TaskStatus.Cancelled, DateTime.Parse("2026-12-13"));
        manager.AddItem("Groceries", TaskStatus.InProgress, DateTime.Parse("2027-01-31"));
        Console.ForegroundColor = ConsoleColor.Yellow;
        manager.ShowByName();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("");
        manager.ShowByDate();
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Cyan;
        manager.PrintByIndex();
        Console.ResetColor();
    }
    
    //Initialise the manager
    public static void InitManager()
    {

        //See if there's a default.json file
        try
        {
            if (File.Exists("default.json"))
            {
                Utilities.WritelnGreen($"Loading from default.json");
                string jsonString = File.ReadAllText("default.json");
                Console.WriteLine(jsonString);
                manager = JsonSerializer.Deserialize<TodoManager>(jsonString)!;
                Thread.Sleep(2000);
            }
            //If not create a new one
            else
            {
                manager = new TodoManager();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
   
}
