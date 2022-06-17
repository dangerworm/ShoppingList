namespace Shopping_List;

public class ShoppingListController
{
    private readonly IReadOnlyCollection<string> _options;

    private readonly ShoppingListService _shoppingListService;

    public ShoppingListController()
    {
        _options = new[]
        {
            Constants.AddItem,
            Constants.EditItem,
            Constants.RemoveItem,
            Constants.Exit
        };

        _shoppingListService = new ShoppingListService();
    }

    public void Run()
    {
        string action;

        do
        {
            Console.WriteLine();
            _shoppingListService.PerformAction(Constants.DisplayList);
            Console.WriteLine();
            
            action = Helpers.GetMenuOptionFromUser(_options);
            _shoppingListService.PerformAction(action);

            Console.Clear();

        } while (action != Constants.Exit);
    }
}
