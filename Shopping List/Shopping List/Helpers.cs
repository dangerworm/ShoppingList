namespace Shopping_List;

public static class Helpers
{
    public static string GetMenuOptionFromUser(IReadOnlyCollection<string> options)
    {
        int menuItem;

        var optionsMap = options
            .Select((item, index) => new { Index = index + 1, Item = item })
            .ToDictionary(x => x.Index, x => x.Item);

        var numberedOptions = optionsMap.Select(x => $"{x.Key}: {x.Value}");

        var menu = string.Join(Environment.NewLine, numberedOptions);

        do
        {
            Console.WriteLine(menu);
            Console.WriteLine();

            Console.Write("Please select an option: ");
            var response = Console.ReadLine();
            menuItem = ParseMenuItem(response ?? string.Empty);

        } while (menuItem == -1);

        return optionsMap[menuItem];
    }

    private static int ParseMenuItem(string response)
    {
        if (string.IsNullOrWhiteSpace(response))
        {
            return -1;
        }

        if (!int.TryParse(response, out var menuItem))
        {
            return -1;
        }

        return menuItem;
    }
}
