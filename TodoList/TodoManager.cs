using System.Text.Json.Serialization;

namespace TodoList;

public class TodoManager
{

    public List<Task> TodoItems {get; set; }


    public TodoManager()
    {
        TodoItems = new();
        
    }   
    
    public void AddItem(string name,  DateTime dueDate)
    {
        //TodoItems.Add(new Task(name, dueDate, false));
        TodoItems.Add(new Task(name, dueDate));
    }

    public void DeleteItem(int index)
    {
        try
        {
            TodoItems.RemoveAt(index);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("No such item");
        }
    }

    public void ToggleItem(int index)
    {
        TodoItems[index].IsDone = !TodoItems[index].IsDone;
    }

    public void PrintByName()
    {
        var data = TodoItems.AsEnumerable();
        var sortedData = 
            from t in data
            orderby t.ProjectName
            select t;
        
        PrintData(sortedData);
        
    }

    

    public void PrintByDate()
    {
        var data = TodoItems.AsEnumerable();
        var sortedData = 
            from t in data
            orderby t.DueDate
            select t;
        
        PrintData(sortedData);
    }

    public Task GetItem(int index)
    {
        return TodoItems[index];
    }
    
    
    private void PrintData(IEnumerable<Task> d)
    {
        Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", "Name", "DueDate", "Status");
        Console.WriteLine("-----------------------------------------------------------");
        string status = "Not done";
        foreach (var item in d)
        {
            if (item.IsDone)
            {
                status = "Done";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                status = "Not done";
            }

            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", item.ProjectName, item.DueDate, status);
            Console.ResetColor();


        }
    }
    
    public void PrintByIndex()
    {
        Console.WriteLine("{0,-15} | {1,-20} | {2,-15} | {3,-15}", "Index", "Name", "Due date m", "Status");
        Console.WriteLine("----------------------------------------------------------------------------");
        string status = "Not done";
        
        foreach (var item in TodoItems)
        {
            if (item.IsDone)
            {
                status = "Done";
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                status = "Not done" + "😰";
            }

            Console.WriteLine("{0,-15} | {1,-20} | {2,-15} | {3,-15}", TodoItems.IndexOf(item), item.ProjectName,
                item.DueDate.ToShortDateString(), status);

            Console.ResetColor();


        }
    }
    
    
    
}