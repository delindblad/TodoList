namespace TodoList;

public class RootPage : MenuPage
{
    

    public RootPage(string title, TodoManager manager) : base(title, null)
    {
        return;
    }

    public void AddChildPage(MenuPage page, string title)
    {
        page.Parent = this;
        ChildPages.Add(page);

    }
    
 


    public override void Display()
    {
        Console.Clear();
        Utilities.WritelnYellow($"{Title} - Submenus:");
        var i = 1;
        foreach (var page in ChildPages)
        {
            Utilities.WritelnYellow($"({i}) {page.Title}");
            i++;
        }
        
    }

    public override void Interact()
    {
        Utilities.WritelnYellow("Select option:");
        var input = Console.ReadKey();
        try
        {
            var n = int.Parse(input.KeyChar.ToString());
            Result = ChildPages[n - 1];
        }
        catch (Exception e)
        {
            Utilities.WritelnRed(e.ToString());
        }
        return;
    }

    public override MenuPage? Run()
    {
        Display();
        Interact();
        return Result;
    }
}