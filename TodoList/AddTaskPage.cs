using System.Runtime.InteropServices.JavaScript;
using MenuPageKit;

namespace TodoList;

public class AddTaskPage : AbstractMenuPage
{
    private readonly TodoManager _manager;
    public AddTaskPage(string title, AbstractMenuPage? parent, TodoManager? m) : base(title, parent)
    {
        _manager = m;
    }
    //Runs when the page is loaded
    public override void OnLoad()
    {
        base.OnLoad();
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("TODO LIST - FOLLOW THE INSTRUCTIONS TO ADD A TASK, TYPE 'Q' ON AN EMPTY LINE TO QUIT");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine();

    }

    public override int Interact()
    {
        return DoAdd();
        
    }
    //RUns the page
    protected override AbstractMenuPage? Run()
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
    //Method for adding tasks
    private int DoAdd()
    {
        string? taskName;
        TaskStatus taskStatus;
        DateTime taskDueDate;
        do
        {
            Console.Write("Enter task name: ");

            // Get task name
            taskName = Console.ReadLine()?.Trim();
            if (taskName?.ToLower() == "q")
            {
                return -1;
            }
            else if (taskName == "")
            {
                Utilities.WritelnRed("Error: Task name cannot be empty");
                Console.Beep();
                continue;
            }

            break;
        } while (true);



        // Get date
        string? dateString = "";
        do
        {
            Console.Write("Enter a valid due date in the form(YYYY-MM-DD) or leave blank for a week from now:");
            dateString = Console.ReadLine()?.Trim();
            if (dateString?.ToLower() == "q")
            {
                return -1;
            }
            if (dateString == "")
            {
                taskDueDate = DateTime.Now.AddDays(7);
                _manager.AddItem(taskName, taskDueDate);
                Utilities.WritelnGreen("Added the following:");
                Console.WriteLine("|{0,-20} | {1,-15}|", taskName, taskDueDate.ToShortDateString());
                Thread.Sleep(2000);
                return 0;
            }
        } while (!DateTime.TryParse(dateString, out taskDueDate));
        
        //Add new task
        _manager.AddItem(taskName, taskDueDate);
        Utilities.WritelnGreen("Added the following:");
        Console.WriteLine("|{0,-20} | {1,-15}|", taskName, taskDueDate.ToShortDateString());
        Thread.Sleep(2000);
        return 0;
        
    
    }
    
}