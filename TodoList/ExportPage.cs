using System.Text.Json;
using MenuPageKit;
namespace TodoList;

public class ExportPage : AbstractMenuPage
{
    TodoManager manager;
    public ExportPage(string title, AbstractMenuPage? parent, TodoManager m) : base(title, parent)
    {
        manager = m;
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("Export - (Esc to cancel)");
    }

    public override int Interact()
    {   
        try
        {
            Utilities.WriteYellow("File name(default.json):");
            var fileName = Console.ReadLine() ?? "";
            if (fileName.Trim().ToLower() == "q")
            {
                return -1;
            }
            SaveFile(fileName);
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
        var i = Interact();
        if (i == -1)
        {
            return Result;
        }
        if (i == 0)
        {
            Utilities.WriteYellow("Press any key to continue...");
            Console.ReadKey();
            return Result;
        }
        return this;
    }
    
    void SaveFile(string fileName)
    {

        try
        {
            if (fileName.Trim() == "")
            {
                fileName = "default.json";
            }
            Utilities.WritelnGreen($"Saving to {fileName}");
            string jsonString = JsonSerializer.Serialize(manager);
            File.WriteAllText(fileName, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}