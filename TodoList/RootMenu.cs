namespace TodoList;

public class RootMenu : MenuPage
{
    

    public RootMenu(string title) : base(title, null)
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
        foreach (var page in ChildPages)
        {
            Utilities.WritelnYellow($"- {page.Title}");
        }
        
    }
}