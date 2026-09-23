using MenuPageKit;

namespace TodoList;

public class ShowTasksPage : AbstractMenuPage
{
    private readonly TodoManager _manager;
    private int _showBy = 0;
    public ShowTasksPage(string title, AbstractMenuPage? parent, TodoManager m) : base(title, parent)
    {
        _manager = m;
    }

    public override void OnLoad()
    {
        base.OnLoad();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Todo List - See display options below");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Type 'D' - to sort by date, 'N' - to sort by name, 'I' to sort by index, 'Q' - to quit");
        Console.WriteLine();
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

    public override AbstractMenuPage Run()
    {
        while (true)
        {

            var i = Interact();
            switch (i)
            {
                case -1:
                    continue;
                case 1:
                    _showBy = 0;
                    Context = this;
                    goto exit;
                    break;
                case 2:
                    _showBy = 1;
                    Context = this;
                    goto exit;
                    break;
                case 3:
                    _showBy = 2;
                    Context = this;
                    goto exit;
                    break;
                case 0:
                    Context = Parent;
                    goto exit;
            }
            

        }
        exit:
        return Context;
    }
}