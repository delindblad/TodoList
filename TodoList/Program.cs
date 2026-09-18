using Microsoft.Extensions.Logging;
namespace TodoList;

public static class Program
{

    static void Main(string[] args)
    {
        ILogger logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger("Main");
        

        var root = new RootMenu("Main Menu");
        root.AddChildPage(new SimpleChildPage("Child Page 1", root));
        root.AddChildPage(new SimpleChildPage("Child Page 2", root));
        root.AddChildPage(new SimpleChildPage("Child Page 3", root));
       // logger.LogInformation("Added simple child pages");
        root.Display();
        
       
       
        
    }
}
