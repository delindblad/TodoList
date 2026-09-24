using MenuPageKit;

namespace TodoList;

public class AddTaskPage : AbstractMenuPage
{
    private readonly TodoManager _manager;
    public AddTaskPage(string title, AbstractMenuPage? parent, TodoManager m) : base(title, parent)
    {
        _manager = m;
    }

    public override void OnLoad()
    {
        base.OnLoad();
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("Todo List - Follow the instructions to add a task, 'Q' on an empty line to quit.");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();

    }

    public override int Interact()
    {
        Console.Write("Enter task name: ");
        string? taskName;
        TaskStatus taskStatus;
        DateTime taskDueDate;
        
        // Get task name
        taskName = Console.ReadLine().Trim();
        if (taskName.ToLower() == "q")
        {
            return -1;
        }
        
        
        
        // Get date
        string dateString = "";
        while(!DateTime.TryParse(dateString, out taskDueDate))
        {
            Console.Write("Enter due date (YYYY-MM-DD):");
            dateString = Console.ReadLine()?.Trim() ?? "";
            if (dateString.ToLower() == "q")
            {
                return -1;
            }
        }
        // Add new task
        _manager.AddItem(taskName, taskDueDate);
        Utilities.WritelnGreen("Added the following:");
        Console.WriteLine("{0,-20} | {1,-15}", taskName, taskDueDate);
        Thread.Sleep(2000);
        return 0;
        
    }

    public override AbstractMenuPage Run()
    {
        while (true)
        {
            OnLoad();
            var i = Interact();
            if (i == -1)
            {
                break;
            }
        }
        return PageContext;
    }
}