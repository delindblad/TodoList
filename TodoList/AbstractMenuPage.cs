namespace MenuPageKit;

public abstract class AbstractMenuPage
{
    public AbstractMenuPage? Context { get; set; } = null;
    public AbstractMenuPage? Parent { get; set; }
    public List<AbstractMenuPage> ChildPages { get; set; }
    public string Title { get; set; }

    public AbstractMenuPage(string title, AbstractMenuPage? parent)
    {
        Title = title;
        ChildPages = new List<AbstractMenuPage>();
        Context = Parent = parent;
    }

    public void AddChildPage(AbstractMenuPage page)
    {
        page.Parent = this;
        ChildPages.Add(page);
    }

    public virtual void OnLoad()
    {
        Console.Clear();
    }

    public abstract int Interact();
 
    public abstract AbstractMenuPage Run();
    
    public static void RunEntryPoint(AbstractMenuPage entryPoint)
    {
        AbstractMenuPage context = entryPoint;
        while (context != null)
        {
            context.OnLoad();
            context = context.Run();
            if (context == null!)
            {
                return;
            }
        }
    }
}