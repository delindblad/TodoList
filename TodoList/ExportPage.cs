using System.Text.Json;
namespace TodoList;

public class ExportPage : MenuPage
{
    TodoManager manager;
    public ExportPage(string title, MenuPage? parent, TodoManager m) : base(title, parent)
    {
        manager = m;
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Export - (Esc to cancel)");
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
            SaveFile(fileName);
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
    
    void SaveFile(string fileName)
    {
        if (fileName.Trim() == "")
        {
            fileName = "default.json";
        }
        Utilities.WritelnGreen($"Saving to {fileName}");
        string jsonString = JsonSerializer.Serialize(manager);
        File.WriteAllText(fileName, jsonString);
    }
}