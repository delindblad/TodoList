using System.Text.Json;
using MenuPageKit;
namespace TodoList;

//Page for importing from .json file
public class ImportPage : AbstractMenuPage
{
    TodoManager? _manager;
    public ImportPage(string title, AbstractMenuPage? parent, TodoManager? m) : base(title, parent)
    {
        _manager = m;
    }

    public override void OnLoad()
    {
        Console.Clear();
        Console.WriteLine("Import from file, ('Q' to cancel)");
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

    protected override AbstractMenuPage? Run()
    {

        Interact();
        return PageContext;
    }
    

    //Loads from .json file
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
            _manager = JsonSerializer.Deserialize<TodoManager>(jsonString)!;
        }
    }
}