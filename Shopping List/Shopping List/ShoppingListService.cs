using System.Security;

namespace Shopping_List
{
    public class ShoppingListService
    {
        private readonly IList<string> _shoppingList;

        public ShoppingListService()
        {
            _shoppingList = new List<string>();
        }

        public void PerformAction(string action)
        {
            switch (action)
            {
                case Constants.AddItem:
                    AddItem();
                    break;
                case Constants.DisplayList:
                    DisplayList();
                    break;
                case Constants.EditItem:
                    EditItem();
                    break;
                case Constants.RemoveItem:
                    RemoveItem();
                    break;
                default:
                    DoNothing();
                    break;
            }
        }

        private void AddItem()
        {
            string item;

            do
            {
                Console.WriteLine();
                Console.Write("Enter new item: ");
                item = Console.ReadLine() ?? string.Empty;

                if (_shoppingList.Contains(item))
                {
                    Console.WriteLine();
                    Console.WriteLine("You have already added that item.");
                    item = string.Empty;
                }

            } while (string.IsNullOrWhiteSpace(item));

            _shoppingList.Add(item);
        }

        private void DisplayList()
        {
            var list = string.Join(Environment.NewLine, _shoppingList);
            
            Console.WriteLine();
            Console.WriteLine(list);
        }

        private void EditItem()
        {
            var item = Helpers.GetMenuOptionFromUser(_shoppingList.ToArray());
            
            string newItem;

            do
            {
                Console.WriteLine();
                Console.Write("Enter replacement: ");
                newItem = Console.ReadLine() ?? string.Empty;

            } while (string.IsNullOrWhiteSpace(newItem));

            var index = _shoppingList.IndexOf(item);
            _shoppingList.RemoveAt(index);
            _shoppingList.Insert(index, newItem);
        }

        private void RemoveItem()
        {
            string item;
            do
            {
                item = Helpers.GetMenuOptionFromUser(_shoppingList.ToArray());

                if (_shoppingList.Contains(item))
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter a number from the list.");
                    item = string.Empty;
                }
            } while (string.IsNullOrWhiteSpace(item));

            _shoppingList.Remove(item);
        }

        private void DoNothing()
        {
        }
    }
}
