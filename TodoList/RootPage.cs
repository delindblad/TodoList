using System.Text.Json;
namespace TodoList;
using MenuPageKit;
public class RootPage : AbstractMenuPage
{
    private TodoManager _manager;
    

    public RootPage(string title, TodoManager manager, AbstractMenuPage parent) : base(title, parent)
    {
        _manager = manager;
        Parent = parent;
        //InitManager();
        
        
    }

    public void AddChildPage(AbstractMenuPage page, string title)
    {
        page.Parent = this;
        ChildPages.Add(page);


    }


    public override void OnLoad()
    {

        base.OnLoad();
        Console.WriteLine($"{Title} - Select an option:");
        var i = 1;
        foreach (var page in ChildPages)
        {
            Console.WriteLine($"({i}) {page.Title}");
            i++;
        }

        Console.WriteLine("");
    }

    public override int Interact()
    {
        Console.WriteLine("Select option:");
        var input = Console.ReadKey().KeyChar;
        if (input.ToString().Trim().ToLower() == "q")
        {
            return -1;
        }
        try
        {
            var n = int.Parse(input.ToString());
            Context = ChildPages[n - 1];
        }
        catch (Exception e)
        {
            Utilities.WritelnRed(e.ToString());
        }

        return 0;
    }

    public override AbstractMenuPage? Run()
    {
        if (Interact() == -1)
        {
            return Parent;
        }
        return Context;
    }

    public void InitManager()
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