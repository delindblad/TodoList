using MenuPageKit;

namespace TodoList;

public class ShowTasksPage : AbstractMenuPage
{
    private readonly TodoManager _manager;
    private int _showBy = 0;

    //Constructor
    public ShowTasksPage(string title, AbstractMenuPage? parent, TodoManager? m) : base(title, parent)
    {
        _manager = m;
    }

    public override void OnLoad()
    {
        base.OnLoad();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("TO DO LIST - SEE DISPLAY OPTIONS BELOW");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
    Console.WriteLine("TYPE 'D' - TO SORT BY DATE, 'N' - TO SORT BY NAME, 'I' TO SORT BY INDEX, 'Q' - TO QUIT");
        Console.WriteLine();
        //Prints the tasks in different orders depending on user input
        if (_showBy == 0)
        {
            _manager.PrintByDate();
        }
        else if (_showBy == 1)
        {
            _manager.PrintByName();
        }
        else if (_showBy == 2)
        {
            _manager.PrintByIndex();
        }
    }
    //Handles user input
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
        else if (key == 'I' || key == 'i')
        {
            return 3;
        }

        {
            return -1;
        }
    }
    //Runs the page
    protected override AbstractMenuPage? Run()
    {
        while (true)
        {
            //Update page context
            var i = Interact();
            switch (i)
            {
                case -1:
                    continue;
                case 1:
                    _showBy = 0;
                    PageContext = this;
                    goto exit;
                    break;
                case 2:
                    _showBy = 1;
                    PageContext = this;
                    goto exit;
                    break;
                case 3:
                    _showBy = 2;
                    PageContext = this;
                    goto exit;
                    break;
                case 0:
                    PageContext = Parent;
                    goto exit;
            }
        }

        exit:
        return PageContext;
    }

    
}