using System.Text.Json;
namespace TodoList;
using MenuPageKit;
public class RootPage : AbstractMenuPage
{
    private TodoManager? _manager;
    
    //Constructor
    public RootPage(string title, TodoManager? manager, AbstractMenuPage parent) : base(title, parent)
    {
        //Assign fields and properties
        _manager = manager;
        Parent = parent;
 
        
        
    }
    //Add children
    public void AddChildPage(AbstractMenuPage page, string title)
    {
        page.Parent = this;
        ChildPages.Add(page);


    }

    //Runs when the page is loaded
    public override void OnLoad()
    {

        base.OnLoad();
        //Create menu
        Console.WriteLine($"{Title}");
        Console.WriteLine("");
        var i = 1;
        foreach (var page in ChildPages)
        {
            Console.WriteLine($"({i}) {page.Title}");
            i++;
        }


    }
    //Handle interaction
    public override int Interact()
    {
        //Get input
        Console.Write("Select option:");
        var input = Console.ReadKey().KeyChar;
        if (input.ToString().Trim().ToLower() == "q")
        {
            return -1;
        }
        try
        {
            //If the option is valid, set page context
            var n = int.Parse(input.ToString());
            PageContext = ChildPages[n - 1];
        }
        catch (Exception e)
        {
            //If the input is invalid, we just run this page again
            PageContext = this;
        }
        return 0;
    }
    //Runs the page
    protected override AbstractMenuPage? Run()
    {
        return Interact() == -1 ? Parent : PageContext;
    }
    
}