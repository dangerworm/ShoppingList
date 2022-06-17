// See https://aka.ms/new-console-template for more information

namespace Shopping_List;

public class Program
{
    public static void Main()
    {
        var controller = new ShoppingListController();
        controller.Run();
    }
}
