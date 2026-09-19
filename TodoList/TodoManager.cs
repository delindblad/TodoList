using System.Text.Json.Serialization;

namespace TodoList;

public class TodoManager
{

    public List<Task> TodoItems {get; set; }


    public TodoManager()
    {
        TodoItems = new List<Task>();
    }
    public void AddItem(string name, TaskStatus status, DateTime dueDate)
    {
        TodoItems.Add(new Task(name, status, dueDate));
    }

    public void RemoveItem(int index)
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

    public void ShowByName()
    {
        var data = TodoItems.AsEnumerable();
        var sortedData = 
            from t in data
            orderby t.ProjectName
            select t;
        
        PrintData(sortedData);
        
    }

    

    public void ShowByDate()
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
        Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", "Name", "Status", "DueDate");
        Console.WriteLine("-----------------------------------------------------------");
        foreach (var item in d)
        {

            Console.WriteLine("{0,-20} | {1,-15} | {2,-15}", item.ProjectName, item.Status, item.DueDate);

        }
    }
    
    public void PrintByIndex()
    {
        Console.WriteLine("{0,-15} | {1,-20} | {2,-15} | {3,-15}", "Index", "Name", "Status", "DueDate");
        Console.WriteLine("----------------------------------------------------------------------------");
        foreach (var item in TodoItems)
        {

            Console.WriteLine("{0,-15} | {1,-20} | {2,-15} | {3,-15}", TodoItems.IndexOf(item), item.ProjectName, item.Status, item.DueDate);

        }
    }
    
    
    
}