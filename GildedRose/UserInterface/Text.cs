namespace GildedRose.UserInterface;

public static class Text
{
    private const string Divider = "--------------------------------";
    public static class Messages
    {
        public const string Welcome = $"{Divider}\nWelcome to Gilded Rose!\n{Divider}";
        public const string Goodbye = $"{Divider}\nThank you for shopping at Gilded Rose!\n{Divider}";
        public const string CurrencyChanged = "Currency changed to: ";
        public const string DiscountApplied = "% Discount applied!";
        public const string AllItemsRemoved = "All items removed from cart.";
    }

    public static class Errors
    {
        public const string InvalidInput = $"{Divider}\nInvalid input. {Instructions.PleaseTryAgain}\n{Divider}";
        public const string ItemNotFound = $"{Divider}\nItem not found. {Instructions.PleaseTryAgain}\n{Divider}";
    }

    public static class Instructions
    {
        private const string GoBack = $"\nType: 'back' to go back.\n{Divider}";

        public const string MainMenu =
            $"{Divider}\nType: 'list' to see all items.\nType: 'cart' to see what's in your shopping cart.\nType: 'currency' to change the currency.\nType: 'days' to choose how many days should pass.\nType: 'exit' to leave Gilded Rose.\n{Divider}";

        public const string List = $"{Divider}\nType the name of an item to add it to your cart.{GoBack}";

        public const string Cart =
            $"{Divider}\nType the name of an item to remove it from your cart.{GoBack}";

        public const string Currency = $"{Divider}\nEnter a currency code (EUR, USD, GBP, JPY):{GoBack}";
        
        public const string Days = $"{Divider}\nEnter a number of days that should pass:{GoBack}";
        
        public const string PleaseTryAgain = "Please try again.";
    }
}