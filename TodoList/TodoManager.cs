using System.Text.Json.Serialization;

namespace TodoList;
//Class stores and manages tasks
public class TodoManager
{

    public List<Task> TodoItems {get; set; }


    public TodoManager()
    {
        //List of tasks
        TodoItems = new();
        
    }   
    //Adds a task to the list
    public void AddItem(string? name,  DateTime dueDate)
    {

        TodoItems.Add(new Task(name, dueDate));
    }
    //Updates a task in the list
    public void UpdateItem(Task item, string name, DateTime dueDate, int index)
    {  
        item.ProjectName = name;
        item.DueDate = dueDate;
        
    }
    //Deletes a task from the list
    public int DeleteItem(int index)
    {
        try
        {
            TodoItems.RemoveAt(index);
            return 0;
        }
        catch (ArgumentOutOfRangeException)
        {   
            return -1;
        }
    }
    //Toggles a task's status
    public void ToggleItem(int index)
    {
        TodoItems[index].IsDone = !TodoItems[index].IsDone;
    }
    //Prints tasks by name
    public void PrintByName()
    {
        var data = TodoItems.AsEnumerable();
        var sortedData = 
            from t in data
            orderby t.ProjectName
            select t;
        
        PrintData(sortedData);
        
    }

    
//Prints tasks by date
    public void PrintByDate()
    {
        var data = TodoItems.AsEnumerable();
        var sortedData = 
            from t in data
            orderby t.DueDate
            select t;
        
        PrintData(sortedData);
    }
    //Returns item at index
    public Task GetItem(int index)
    {
        return TodoItems[index];
    }
    //Returns true if index is valid
    public bool HasIndex(int index)
    {

        if (TodoItems.Count >= (index + 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    //Utility method for printing data
    private void PrintData(IEnumerable<Task> d)
    {
        Console.WriteLine("|{0,-20} | {1,-15} | {2,-15}|", "Name", "Due date", "Status");
        Console.WriteLine("-----------------------------------------------------------");
        string status = "";
        foreach (var item in d)
        {
            if (item.IsDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                status = "Done!       🥳";
            }
            else
            {
                if (item.DueDate.CompareTo(DateTime.Now) < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    status = "Not done... 🥶";
                }
                else if (item.DueDate.CompareTo(DateTime.Now.AddDays(12)) < 1 )
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    status = "Not done... 😱";
                }
                else
                {
                    status = "Not done... 🤔";
                }
            }

            Console.WriteLine("|{0,-20} | {1,-15} | {2,-15}|", item.ProjectName, item.DueDate.ToShortDateString(), status);
            Console.ResetColor();


        }
    }
    //Prints tasks by index
    public void PrintByIndex()
    {
        Console.WriteLine("|{0,-15} | {1,-20} | {2,-15} | {3,-15}|", "Index", "Name", "Due date", "Status");
        Console.WriteLine("----------------------------------------------------------------------------");
        string status = "";
        
        foreach (var item in TodoItems)
        {
            if (item.IsDone)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                status = "Done!       🥳";
            }
            else
            {
                if (item.DueDate.CompareTo(DateTime.Now) < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    status = "Not done... 🥶";
                }
                else if (item.DueDate.CompareTo(DateTime.Now.AddDays(12)) < 1 )
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    status = "Not done... 😱";
                }
                else
                {
                    status = "Not done... 🤔";
                }
            }

            Console.WriteLine("|{0,-15} | {1,-20} | {2,-15} | {3,-15}|", TodoItems.IndexOf(item), item.ProjectName,
                item.DueDate.ToShortDateString(), status);

            Console.ResetColor();


        }
    }
    
    
    
}