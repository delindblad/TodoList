using Microsoft.Extensions.Logging;
using MenuPageKit;
namespace TodoList;

public class SimpleChildPage : AbstractMenuPage
{

    
    public SimpleChildPage(string title, AbstractMenuPage? parent) : base(title, parent)
    {
        
    }

    public override void Display()
    {
        return;
    }

    public override int Interact()
    {
        throw new NotImplementedException();
    }

    public override AbstractMenuPage Run()
    {
        throw new NotImplementedException();
    }
}