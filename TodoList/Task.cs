namespace TodoList;

public class Task
{
    string ProjectName { get; set; }
    TaskStatus Status { get; set; }
    DateTime DueDate { get; set; }
    
    public Task(string name, TaskStatus status, DateTime dueDate)
    {
        ProjectName = name;
        Status = status;
        DueDate = dueDate;
    }
}

public enum TaskStatus
{
    NotStarted,
    OnHold,
    Done,
    Cancelled
}