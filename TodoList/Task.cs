namespace TodoList;

//Stores information about a task
public class Task
{
    //Properties
    public bool IsDone { get; set; }
    public string? ProjectName { get; set; }
    public DateTime DueDate { get; set; }
    
    //Constructor
    public Task(string? projectName, DateTime dueDate)
    {
        DueDate = dueDate;
        ProjectName = projectName;
        IsDone = false;
    }

    
}


