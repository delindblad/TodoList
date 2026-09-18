namespace TodoList;

public interface IMenuPage
{
    MenuPage? Parent { get; set; }
    List<(IMenuPage, string)> ChildPages { get; set; }
    string Title { get; set; }
    
    public void AddChildPage(IMenuPage page, string title);
    public void Display();
    
    
}