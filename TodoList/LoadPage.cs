using System.Text.Json;
namespace TodoList;

public class LoadPage : MenuPage
{
    TodoManager manager;
    public LoadPage(string title, MenuPage? parent, TodoManager m) : base(title, parent)
    {
        manager = m;
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Load from file, (Esc to cancel)");
    }

    public override void Interact()
    {   
        try
        {
            Utilities.WriteYellow("File name(default.json):");
            var fileName = Console.ReadLine() ?? "";
            if (fileName.Trim().ToLower() == "q")
            {
                return;
            }
            LoadFile(fileName);
            Utilities.WriteYellow("Press any key to continue...");
            Console.ReadKey();
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }

    public override MenuPage Run()
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