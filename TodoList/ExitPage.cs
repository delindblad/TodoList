namespace TodoList;

public class ExitPage : IMenuPage
{
    public MenuPage? Parent { get; set; } = null;
    public List<(IMenuPage, string)> ChildPages { get; set; }
    public string Title { get; set; }
    public void AddChildPage(IMenuPage page, string title)
    {
        throw new NotImplementedException();
    }

    public void Display() => throw new NotImplementedException();
}