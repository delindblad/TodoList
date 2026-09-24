using System.Text.Json;
using MenuPageKit;

namespace TodoList;

//Page saves and exits the program when loaded
public class ExitPage : AbstractMenuPage
{
    readonly TodoManager? _manager;
    public ExitPage(string title, AbstractMenuPage? parent, TodoManager? manager) : base(title, parent)
    {
        _manager = manager;
    }

    public override void OnLoad()
    {
        base.OnLoad();
    }

    public override int Interact()
    {
        return 0;
    }

    protected override AbstractMenuPage Run()
    {
        try
        //Save to file
        {
            Utilities.WritelnGreen($"Saving to default.json");
            string jsonString = JsonSerializer.Serialize(_manager);
            //Console.WriteLine(jsonString);
            File.WriteAllText("default.json", jsonString);
            Thread.Sleep(2000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            System.Environment.Exit(0);
        }
        System.Environment.Exit(0);
        return null;

    }
}