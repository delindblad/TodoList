using System.Text.Json;
using MenuPageKit;
namespace TodoList;

public class LoadPage : AbstractMenuPage
{
    TodoManager manager;
    public LoadPage(string title, AbstractMenuPage? parent, TodoManager m) : base(title, parent)
    {
        manager = m;
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Load from file, (Esc to cancel)");
    }

    public override int Interact()
    {   
        try
        {
            Utilities.WriteYellow("File name(default.json):");
            var fileName = Console.ReadLine() ?? "";
            if (fileName.Trim().ToLower() == "q")
            {
                return 0;
            }
            LoadFile(fileName);
            Utilities.WriteYellow("Press any key to continue...");
            Console.ReadKey();
            return 0;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }

    public override AbstractMenuPage Run()
    {
        Display();
        Interact();
        return Result;
    }
    

    
    void LoadFile(string fileName)
    {
        if (fileName.Trim() == "")
        {
            fileName = "default.json";
        }

        if (File.Exists(fileName))
        {
            Utilities.WritelnGreen($"Loading from {fileName}");
            string jsonString = File.ReadAllText(fileName);
            manager = JsonSerializer.Deserialize<TodoManager>(jsonString)!;
        }
    }
}