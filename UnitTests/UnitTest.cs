namespace TestProject1;

public class UnitTest
{
    [Fact]
    public void Test1()
    {
        var root = new TodoList.RootMenu("Main Menu");
        var child1 = new TodoList.SimpleChildPage("Child Page 1", root);
        var child2 = new TodoList.SimpleChildPage("Child Page 2", root);

        root.AddChildPage(child1);
        root.AddChildPage(child2);

        Assert.Equal("Main Menu", root.Title);
        Assert.Equal(2, root.ChildPages.Count);
        Assert.Contains(child1, root.ChildPages);
        Assert.Contains(child2, root.ChildPages);
        Assert.Equal(root, child1.Parent);
        Assert.Equal(root, child2.Parent);
    }
}