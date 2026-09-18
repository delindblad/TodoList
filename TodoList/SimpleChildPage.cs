using Microsoft.Extensions.Logging;

namespace TodoList;

public class SimpleChildPage : MenuPage
{

    
    public SimpleChildPage(string title, MenuPage? parent) : base(title, parent)
    {
        
    }

    public override void Display()
    {
        return;
    }

    public override void Interact()
    {
        throw new NotImplementedException();
    }

    public override MenuPage Run()
    {
        throw new NotImplementedException();
    }
}