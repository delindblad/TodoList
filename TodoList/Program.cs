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
        //Initiate manager
        InitManager();
        Run();
        
        



    }
    
    public static void Run()

    {
        ExitPage exitPage = new ExitPage("Exit", null, manager);
        var root = new RootPage("Todo List Manager", manager, exitPage);
        root.AddChildPage(new ShowTasksPage("Show tasks", root, manager));
        root.AddChildPage(new AddTaskPage("Add task", root, manager));
        root.AddChildPage(new EditTaskPage("Edit task", root, manager));
        root.AddChildPage(new ImportPage("Load from file", root, manager));
        root.AddChildPage(new ExportPage("Export to file", root, manager));
        //logger.LogInformation("Added simple child pages");
        
        AbstractMenuPage.RunEntryPoint(root);


  
    }


    public static void Test()
    {

        manager.AddItem("Cleaning", DateTime.Parse("2026-10-01"));
        manager.AddItem("Laundry" , DateTime.Parse("2026-11-07"));
        manager.AddItem("Groceries", DateTime.Parse("2026-12-13"));
        manager.AddItem("Groceries", DateTime.Parse("2027-01-31"));
        Console.ForegroundColor = ConsoleColor.Yellow;
        manager.PrintByName();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("");
        manager.PrintByDate();
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
                //Console.WriteLine(jsonString);
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
