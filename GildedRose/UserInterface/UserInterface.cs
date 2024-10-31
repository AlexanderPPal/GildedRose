using GildedRose.Items;
using GildedRose.Price;

namespace GildedRose.UserInterface;

public static class Ui
{
    public static string? UserInput { get; private set; }
    public static string UserCurrency { get; private set; } = "EUR";

    public static void PrintInstructions()
    {
        Console.WriteLine(
            "Type: 'list' to see all items.\n" +
            "Type: 'cart' to see what's in your shopping cart.\n" +
            "Type: 'currency' to change the currency.\n" +
            "Type: 'exit' to leave Gilded Rose.");
    }

    private static void PrintListInstructions()
    {
        Console.WriteLine("Type the name of an item to add it to your cart.\n" +
                          "Type: 'back' to go back.");
    }
    
    private static void PrintCartInstructions()
    {
        Console.WriteLine("Type the name of an item to remove it from your cart.\n" +
                          "Type: 'back' to go back.");
    }

    public static void HandleUserInput()
    {
        UserInput = Console.ReadLine();
        switch (UserInput)
        {
            case "list":
                ItemList.PrintItems();
                PrintListInstructions();
                while (UserInput != "back")
                {
                    UserInput = Console.ReadLine();
                    if (UserInput != "back")
                    {
                        if (UserInput != null)
                        {
                            ItemList.AddItemToCart(UserInput);
                        }
                        else
                        {
                            PrintListInstructions();
                        }
                    }
                }
                break;
            case "cart":
                ItemList.PrintCart();
                PrintCartInstructions();
                while (UserInput != "back")
                {
                    UserInput = Console.ReadLine();
                    if (UserInput != "back")
                    {
                        if (UserInput != null)
                        {
                            ItemList.RemoveItemFromCart(UserInput);
                        }
                        else
                        {
                            PrintCartInstructions();
                        }
                    }
                }
                break;
            case "currency":
                Console.WriteLine("Enter a currency code (EUR, USD, GBP, JPY):\n" +
                "Type: 'back' to go back.");
                UserInput = Console.ReadLine();
                if (UserInput != "back")
                {
                    if (CurrencyConverter.GetCurrencies().Contains(UserInput))
                    {
                        UserCurrency = UserInput;
                    }
                    else
                    {
                        Console.WriteLine("Currency not supported.");
                    }
                }
                break;
            case "exit":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid input. Please try again.\n");
                PrintInstructions();
                break;
        }
    }
}