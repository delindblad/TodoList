using MenuPageKit;

namespace TodoList;

public class ShowTasksPage : AbstractMenuPage
{
    TodoManager manager;
    private bool showByDate = false;
    public ShowTasksPage(string title, AbstractMenuPage? parent, TodoManager m) : base(title, parent)
    {
        manager = m;
    }

    public override void Display()
    {
        Console.Clear();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Todo List - See display options below");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Type 'D' - to sort by date, 'N' - to sort by name, 'Q' - to quit");
        Console.WriteLine();
        if (showByDate)
        {
            manager.ShowByDate();
        }
        else
        {
            manager.ShowByName();
        }
        

    }

    public override int Interact()
    {
        var key = Console.ReadKey().KeyChar;
        if (key == 'Q' || key == 'q')
        {
            return 0;
        }
        else if (key == 'D' || key == 'd')
        {
            return 1;
        }
        else if (key == 'N' || key == 'n')
        {
            return 2;
        }
        else
        {
            return -1;
        }
        
    }

    public override AbstractMenuPage Run()
    {
        while (true)
        {
            Display();
            var i = Interact();
            switch (i)
            {
                case -1:
                    continue;
                case 1:
                    showByDate = true;
                    break;
                case 2:
                    showByDate = false;
                    break;
                case 0:
                    goto exit;
            }
            

        }
        exit:
        return Result;
    }
}