using System.Text.Json;
using Microsoft.Extensions.Logging;
namespace TodoList;

public static class Program
{

    static void Main(string[] args)
    {
        ILogger logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger("Main");
        TodoManager manager;
        try
        {
            if (File.Exists("default.json"))
            {
                Utilities.WritelnGreen($"Loading from default.json");
                string jsonString = File.ReadAllText("default.json");
                manager = JsonSerializer.Deserialize<TodoManager>(jsonString)!;
                Thread.Sleep(2000);
            }
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
        
        

        var root = new RootPage("Main Menu", manager);
        root.AddChildPage(new SimpleChildPage("Child Page 1", root));
        root.AddChildPage(new SimpleChildPage("Child Page 2", root));
        root.AddChildPage(new LoadPage("Load from file", root, manager));
        root.AddChildPage(new ExportPage("Save to file", root, manager));
        //logger.LogInformation("Added simple child pages");
        MenuPage p = root.Run();
        p.Run().Run();



    }
}
