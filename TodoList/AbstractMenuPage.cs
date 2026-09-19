namespace MenuPageKit;

public abstract class AbstractMenuPage
{
    public AbstractMenuPage? Result { get; set; } = null;
    public AbstractMenuPage? Parent { get; set; }
    public List<AbstractMenuPage> ChildPages { get; set; }
    public string Title { get; set; }

    public AbstractMenuPage(string title, AbstractMenuPage? parent)
    {
        Title = title;
        ChildPages = new List<AbstractMenuPage>();
        Result = Parent = parent;
    
        
    }
    public void AddChildPage(AbstractMenuPage page)
    {
        ChildPages.Add(page);
    }

    public abstract void Display();
    public abstract int Interact();
    public abstract AbstractMenuPage Run();
}