using System.Text.Json;
using MenuPageKit;
namespace TodoList;

//Page for exporting to .json file
public class ExportPage : AbstractMenuPage
{
    readonly TodoManager? _manager;
    public ExportPage(string title, AbstractMenuPage? parent, TodoManager? m) : base(title, parent)
    {
        _manager = m;
    }

    public override void OnLoad()
    {
        Console.Clear();
        Console.WriteLine("Export - ('Q' to cancel)");
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

    protected override AbstractMenuPage? Run()
    {
        var i = Interact();
        if (i == -1)
        {
            return PageContext;
        }
        if (i == 0)
        {
            Utilities.WriteYellow("Press any key to continue...");
            Console.ReadKey();
            return PageContext;
        }
        return this;
    }
    //Saves to .json file
    void SaveFile(string fileName)
    {

        try
        {
            if (fileName.Trim() == "")
            {
                fileName = "default.json";
            }
            Utilities.WritelnGreen($"Saving to {fileName}");
            string jsonString = JsonSerializer.Serialize(_manager);
            File.WriteAllText(fileName, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}