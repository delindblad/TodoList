namespace TodoList;

public abstract class MenuPage
{
    public MenuPage? Parent { get; set; }
    public List<MenuPage> ChildPages { get; set; }
    public string Title { get; set; }

    public MenuPage(string title, MenuPage? parent)
    {
        Title = title;
        ChildPages = new List<MenuPage>();
        Parent = parent;
        
    }
    public void AddChildPage(MenuPage page)
    {
        ChildPages.Add(page);
    }

    public abstract void Display();
}