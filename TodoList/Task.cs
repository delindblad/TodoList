namespace TodoList;

public class Task
{
    public string ProjectName { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime DueDate { get; set; }
    
    public Task(string name, TaskStatus status, DateTime dueDate)
    {
        SetProperties(name, status, dueDate);
    }

    public void SetProperties(string name, TaskStatus status, DateTime dueDate)
    {
        ProjectName = name;
        Status = status;
        DueDate = dueDate;
    }
}

public enum TaskStatus
{
    NotStarted,
    InProgress,
    OnHold,
    Done,
    Cancelled
}