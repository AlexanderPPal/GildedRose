namespace GildedRose.UserInterface;

public static class Text
{
    public static class Messages
    {
        public const string Welcome = "Welcome to Gilded Rose!";
        public const string Goodbye = "Thank you for shopping at Gilded Rose!";
        public const string CurrencyChanged = "Currency changed to: ";
        public const string DiscountApplied = "% Discount applied!";
    }

    public static class Errors
    {
        public const string InvalidInput = "Invalid input. Please try again.";
        public const string ItemNotFound = "Item not found. Please try again.";
    }

    public static class Instructions
    {
        private const string GoBack = "Type: 'back' to go back.";
        private const string Divider = "\n-------------------";

        public const string MainMenu =
            $"Type: 'list' to see all items.\nType: 'cart' to see what's in your shopping cart.\nType: 'currency' to change the currency.\nType: 'days' to choose how many days should pass.\nType: 'exit' to leave Gilded Rose. {Divider}";

        public const string List = $"Type the name of an item to add it to your cart.\n{GoBack}{Divider}";

        public const string Cart =
            $"Type the name of an item to remove it from your cart.\n{GoBack}{Divider}";

        public const string Currency = $"Enter a currency code (EUR, USD, GBP, JPY):\n{GoBack}{Divider}";
        
        public const string Date = $"Enter a number of days that should pass:\n{GoBack}{Divider}";
    }
}