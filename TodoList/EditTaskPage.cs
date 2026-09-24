using MenuPageKit;

namespace TodoList;

public class EditTaskPage : AbstractMenuPage
{
    private readonly TodoManager _manager;
    public EditTaskPage(string title, AbstractMenuPage? parent, TodoManager manager) : base(title, parent)
    {
        if (parent == null)
        {
            throw new ArgumentNullException(nameof(parent));
        }
        _manager = manager;
    }

    public override void OnLoad()
    {
        base.OnLoad();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("EDIT TO DO LIST");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
        Console.WriteLine("TYPE 'D' - TO DELETE A TASK, 'T' - TO TOGGLE STATUS(Completed/Uncompleted), 'U' TO UPDATE TASK, 'Q' - TO QUIT");
        Console.WriteLine();
        _manager.PrintByIndex();
    }

    public override int Interact()
    {
        var key = Console.ReadKey().KeyChar;
        Console.WriteLine();
        //If 'q' abort.
        if (key == 'Q' || key == 'q')
        {
            return 0;
        }
        else if (key == 'D' || key == 'd')
        {   
            return DoDelete();
        }
        else if (key == 'T' || key == 't')
        {
            return DoToggle();
        }
        else if (key == 'U' || key == 'u')
        {
            return 3;
        }
        
        {
            return -1;
        }

        int DoDelete()
        {
            int index = AskForIndex("Index to delete(q to cancel): ", "ERROR: Please enter a valid index");
            Console.WriteLine();
            if (index == -1)
            {
                return 0;
            }
            _manager.DeleteItem(index);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine("Item with index {0} deleted!", index.ToString());
            
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();
            return 1;
        }

        int DoToggle()
        {
            int index = AskForIndex("Index to toggle(q to cancel): ", "ERROR: Please enter a valid index");
            Console.WriteLine();
            if (index == -1)
            {
                return 0;
            }
            _manager.ToggleItem(index);
            return 2;
        }

    }

    public override AbstractMenuPage Run()
    {
        int n =  Interact();
        if (n == 0)
        {
            PageContext = Parent;
        }
        else if (n == 1)
        {
            PageContext = this;
        }
        else if (n == 2)
        {
            PageContext = this;
        }

        if (PageContext == null)
        {
            throw new ArgumentNullException(nameof(PageContext));
        }
        return PageContext;
    }

    private int AskForIndex(string question, string errorMessage)
    {
        do
        {
            Console.WriteLine(question);
            Console.WriteLine();
            var answer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (answer == 'q' || answer == 'Q')
            {
                return -1;
            }

            if (int.TryParse(answer.ToString(), out int intAnswer))
                
            {
                return intAnswer;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
            Console.Beep();
        } while (true);
    }
    
}