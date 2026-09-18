namespace TodoList;

public class TodoManager
{
    private List<Task> todoItems = new List<Task>();


    public void AddItem(Task item)
    {
        todoItems.Add(item);
    }

    public Task GetItem(int index)
    {
        return todoItems[index];
    }
}