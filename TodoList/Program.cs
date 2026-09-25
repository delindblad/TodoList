
using System.Text.Json;
using MenuPageKit;


namespace TodoList;
//Main class
public static class Program
{
    private static TodoManager? _manager;

    static void Main(string[] args)
    {
        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true; 
            // Save the data if program is interrupted
            try
            {
                Utilities.WritelnRed("Program interrupted!");
                Utilities.WritelnGreen($"Saving to default.json");
                string jsonString = JsonSerializer.Serialize(_manager);
                //Console.WriteLine(jsonString);
                File.WriteAllText("default.json", jsonString);
                Thread.Sleep(2000);
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2);
                System.Environment.Exit(0);
            }
            System.Environment.Exit(0);
            
        };
        
        //Initiate manager
        InitManager();
        //Build the menu structure
        //Convenience page used to exit the app
        ExitPage exitPage = new ExitPage("Exit", null, _manager);
        //Root page, has the exit page as parent    
        var root = new RootPage("Todo List Manager", _manager, exitPage);
        //Add child pages
        root.AddChildPage(new ShowTasksPage("Show tasks", root, _manager));
        root.AddChildPage(new AddTaskPage("Add task", root, _manager));
        root.AddChildPage(new EditTaskPage("Edit task", root, _manager));
        root.AddChildPage(new ImportPage("Import from file", root, _manager));
        root.AddChildPage(new ExportPage("Export to file", root, _manager));
        //Run the roo page
        AbstractMenuPage.RunEntryPoint(root);
    }
    
    //Initialise the manager
    private static void InitManager()
    {

        //See if there's a default.json file
        try
        {
            if (File.Exists("default.json"))
            {
                Utilities.WritelnGreen($"Loading from default.json");
                
                string jsonString = File.ReadAllText("default.json");
                //Console.WriteLine(jsonString);
                _manager = JsonSerializer.Deserialize<TodoManager>(jsonString)!;
                
                Thread.Sleep(2000);
            }
            //If not create a new one
            else
            {
                _manager = new TodoManager();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
   
}
