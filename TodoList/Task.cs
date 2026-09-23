namespace TodoList;

public class Task
{
    public bool IsDone { get; set; }
    public string ProjectName { get; set; }
    public DateTime DueDate { get; set; }
    
    public Task(string projectName, DateTime dueDate)
    {
        DueDate = dueDate;
        ProjectName = projectName;
        IsDone = false;
    }

    
}


