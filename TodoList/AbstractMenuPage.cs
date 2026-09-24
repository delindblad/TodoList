namespace MenuPageKit;

public abstract class AbstractMenuPage
{
    public AbstractMenuPage? PageContext { get; set; } = null;
    public AbstractMenuPage? Parent { get; set; }
    public List<AbstractMenuPage> ChildPages { get; set; }
    public string Title { get; set; }

    public AbstractMenuPage(string title, AbstractMenuPage? parent)
    {
        Title = title;
        ChildPages = new List<AbstractMenuPage>();
        PageContext = Parent = parent;
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

    protected abstract AbstractMenuPage? Run();

    protected string AskQuestion(string question, string errorMessage)
    {
        string? answer;
        do
        {
            Console.WriteLine(question);
            answer = Console.ReadLine();
            if (!string.IsNullOrEmpty(answer)) return answer;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
            Console.Beep();
        } while (true);
    }
    
    protected int AskQuestionInt(string question, string errorMessage)
    {
        string? answer;
        int intAnswer;
        do
        {
            Console.WriteLine(question);
            answer = Console.ReadLine();
            if (int.TryParse(answer, out intAnswer)) return intAnswer;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
            Console.Beep();
        } while (true);
    }
    
    public static void RunEntryPoint(AbstractMenuPage? entryPoint)
    {
        AbstractMenuPage? context = entryPoint;
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