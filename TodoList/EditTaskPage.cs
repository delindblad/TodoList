using MenuPageKit;

namespace TodoList;

public class EditTaskPage : AbstractMenuPage
{
    private readonly TodoManager? _manager;

    //Constructor
    public EditTaskPage(string title, AbstractMenuPage? parent, TodoManager? manager) : base(title, parent)
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
        Console.WriteLine(
            "TYPE 'D' - TO DELETE A TASK, 'T' - TO TOGGLE STATUS(Completed/Uncompleted), 'U' TO UPDATE TASK, 'Q' - TO QUIT");
        Console.WriteLine();
        //Prints the tasks ordered by index
        _manager?.PrintByIndex();
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
            return DoUpdate();
        }

        {
            return -1;
        }

        //Handeles interaction regarding deletino of tasks
        int DoDelete()
        {
            int index = TryDelete("Index to delete(q to cancel): ", "ERROR: Please enter a valid index");
            if (index == -1)
            {
                return 0;
            }

            Console.Clear();
            Utilities.WritelnGreen("Task with index " + index + " deleted!");
            Thread.Sleep(2000);

            return 1;
        }

        //Handles toggling of status
        int DoToggle()
        {
            int index = AskForIndex();
            Console.WriteLine();
            if (index == -1)
            {
                return 0;
            }

            _manager?.ToggleItem(index);
            return 2;
        }
    }

    //Run the page
    protected override AbstractMenuPage Run()
    {
        int n = Interact();
        //Update page context
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
        else if (n == 3)
        {
            PageContext = this;
        }

        if (PageContext == null)
        {
            throw new ArgumentNullException(nameof(PageContext));
        }

        return PageContext;
    }

    //Handles input of index and validity checking
    private int AskForIndex()
    {
        do
        {
            string errorMessage = "ERROR: Please enter a valid index";
            Console.Write("Index:");
            var answer = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (answer == 'q' || answer == 'Q')
            {
                return -1;
            }

            if (int.TryParse(answer.ToString(), out int intAnswer))

            {   
                if (!_manager!.HasIndex(intAnswer))
                {
                    errorMessage = "ERROR: No such index, please enter a valid index";
                }
                else
                {
                    return intAnswer;
                }
            }

            Utilities.WritelnRed(errorMessage);
            Console.Beep();
        } while (true);
    }
    //Utility method used by DoDelete()
    private int TryDelete(string question, string errorMessage)
    {
        do
        {
            Console.Write(question);
            var answer = Console.ReadKey().KeyChar;

            if (answer == 'q' || answer == 'Q')
            {
                return -1;
            }

            if (int.TryParse(answer.ToString(), out int intAnswer) && _manager != null && _manager.DeleteItem(intAnswer) != -1)
            {
                return intAnswer;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
            Console.Beep();
            Thread.Sleep(2000);
        } while (true);
    }
    //Handles updating of tasks, similar to DoAdd() in AddTaskPage
    private int DoUpdate()
    {   //Get input and validate
        int index = AskForIndex();
        //If the user wants to cancel...
        if (index == -1)
        {
            return -1;
        }
        //Gets the current info
        string? taskName = _manager?.GetItem(index).ProjectName;
        DateTime taskDueDate = _manager.GetItem(index).DueDate;
        string taskStatus = _manager.GetItem(index).IsDone ? "Done!" : "Not done...";
        Utilities.WritelnGreen("Current info:");
        Console.WriteLine("|{0,-20} | {1,-15} | {2, -15}|", taskName, taskDueDate.ToShortDateString(), taskStatus);
        //Get input
        do
        {
            Console.Write("Enter task name(\"" + taskName + "\")" + ":");

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
        string? dateString = taskDueDate.ToShortDateString();
        do
        {
            Console.Write("Enter a valid due date in the form(YYYY-MM-DD))" + "\"" + taskDueDate.ToShortDateString() +
                          "\")" + ":");
            dateString = Console.ReadLine()?.Trim();
            if (dateString == "")
            {
                dateString = taskDueDate.ToShortDateString();
            }

            if (dateString?.ToLower() == "q")
            {
                return -1;
            }
        } while (!DateTime.TryParse(dateString, out taskDueDate));

        //Update task
        _manager.UpdateItem(_manager.GetItem(index), taskName, taskDueDate, index);
        Utilities.WritelnGreen("Updated task:");
        Console.WriteLine("|{0,-20} | {1,-15} | {2, -15}|", taskName, taskDueDate.ToShortDateString(), taskStatus);
        Thread.Sleep(2000);
        return 3;
    }
}