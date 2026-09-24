namespace TestProject1;

using TodoList;

public class UnitTest
{
    [Fact]
    public void Test1()
    {
        var todoManager = new TodoManager();
        var dueDate = DateTime.Today.AddDays(1);

        todoManager.AddItem("Test Task", dueDate);

        Assert.Single(todoManager.TodoItems);
        Assert.Equal("Test Task", todoManager.TodoItems[0].ProjectName);
        Assert.Equal(dueDate, todoManager.TodoItems[0].DueDate);
        Assert.False(todoManager.TodoItems[0].IsDone);
    }
}