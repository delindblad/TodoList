using System.Text.Json;
using MenuPageKit;

namespace TodoList;

public class ExitPage : AbstractMenuPage
{
    readonly TodoManager _manager;
    public ExitPage(string title, AbstractMenuPage? parent, TodoManager manager) : base(title, parent)
    {
        _manager = manager;
    }

    public override void OnLoad()
    {
        base.OnLoad();
    }

    public override int Interact()
    {
        throw new NotImplementedException();
    }

    public override AbstractMenuPage Run()
    {
        try
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