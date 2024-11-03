namespace GildedRose.UserInterface;

public static class Text
{
    public static class Messages
    {
        public const string Welcome = "Welcome to Gilded Rose!";
        public const string Goodbye = "Thank you for shopping at Gilded Rose!";
    }

    public static class Errors
    {
        public const string InvalidInput = "Invalid input. Please try again.";
    }

    public static class Instructions
    {
        private const string GoBack = "Type: 'back' to go back.";

        public const string MainMenu =
            "Type: 'list' to see all items.\nType: 'cart' to see what's in your shopping cart.\nType: 'currency' to change the currency.\nType: 'exit' to leave Gilded Rose.";

        public const string List = "Type the name of an item to add it to your cart.\n" + GoBack;

        public const string Cart =
            "Type the name of an item to remove it from your cart.\n" + GoBack;

        public const string Currency = "Enter a currency code (EUR, USD, GBP, JPY):\n" + GoBack;
    }
}