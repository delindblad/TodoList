using System.Text.Json;

namespace TodoList;
using MenuPageKit;
public class RootPage : AbstractMenuPage
{
    readonly TodoManager _manager;
    

    public RootPage(string title, TodoManager manager) : base(title, null)
    {
        _manager = manager;
    }

    public void AddChildPage(AbstractMenuPage page, string title)
    {
        page.Parent = this;
        ChildPages.Add(page);

    }
    
 


    public override void Display()
    {
        Console.Clear();
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
            Result = ChildPages[n - 1];
        }
        catch (Exception e)
        {
            Utilities.WritelnRed(e.ToString());
        }

        return 0;
    }

    public override AbstractMenuPage? Run()
    {
        Display();
        if (Interact() == -1)
        {
            try
            {
                Console.WriteLine();
                Utilities.WritelnGreen($"Saving to default.json");
                string jsonString = JsonSerializer.Serialize(_manager);
                Console.WriteLine(jsonString);
                File.WriteAllText("default.json", jsonString);
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return null;
        }
        return Result;
    }
}