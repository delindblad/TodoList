using MenuPageKit;

namespace TodoList;

public class AddTaskPage : AbstractMenuPage
{
    TodoManager manager;
    public AddTaskPage(string title, AbstractMenuPage? parent, TodoManager m) : base(title, parent)
    {
        manager = m;
    }

    public override void Display()
    {
        Console.Clear();
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
        
        // Get initial status
        var statusString = "";
        do
        {
            Console.Write("Initial status, (0) In progress, (1) Not Started:");
            statusString = Console.ReadLine()?.Trim() ?? "";
        }
        while (statusString != "0" && statusString != "1" && statusString != "Q");
        
        if (statusString == "0")
        {
            taskStatus = TaskStatus.InProgress;
        }
        else if (statusString == "1")
        {
            taskStatus = TaskStatus.NotStarted;
        }
        else
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
        manager.AddItem(taskName, taskStatus, taskDueDate);
        Utilities.WritelnGreen("Added the following:");
        Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", taskName, taskStatus, taskDueDate);
        Thread.Sleep(2000);
        return 0;
        
    }

    public override AbstractMenuPage Run()
    {
        while (true)
        {
            Display();
            var i = Interact();
            if (i == -1)
            {
                break;
            }
        }
        return Result;
    }
}