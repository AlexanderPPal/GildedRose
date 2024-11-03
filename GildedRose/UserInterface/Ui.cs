using GildedRose.Customer;
using GildedRose.Price;
using GildedRose.Store;

namespace GildedRose.UserInterface;

public static class Ui
{
    public static string? UserInput { get; private set; }
    private static bool EndCommand { get; set; }

    public static void RunMainMenu()
    {
        UserInput = Console.ReadLine();
        switch (UserInput?.ToLower())
        {
            case "list":
                HandleListCommand();
                break;
            case "cart":
                HandleCartCommand();
                break;
            case "currency":
                HandleCurrencyCommand();
                break;
            case "days":
                HandleDaysCommand();
                break;
            case "exit":
                HandleExitCommand();
                break;
            default:
                HandleInvalidInput();
                break;
        }
        EndCommand = false;
    }
    
    private static void CheckForBackCommand()
    {
        UserInput = Console.ReadLine();
        EndCommand = UserInput?.ToLower() == "back";
    }

    private static void HandleListCommand()
    {
        GildedRoseStore.PrintStoreItems();
        Console.WriteLine(Text.Instructions.List);
        do
        {
            CheckForBackCommand();
            switch (EndCommand)
            {
                case false when UserInput != null:
                    GildedRoseCustomer.AddItemToCart(UserInput);
                    break;
                case false:
                    Console.WriteLine(Text.Instructions.List);
                    break;
            }
        }while (!EndCommand);
    }
    private static void HandleCartCommand()
    {
        GildedRoseCustomer.PrintCartItems();
        Console.WriteLine(Text.Instructions.Cart);
        do
        {
            CheckForBackCommand();
            switch (EndCommand)
            {
                case false when UserInput != null:
                    GildedRoseCustomer.RemoveItemFromCart(UserInput);
                    break;
                case false:
                    Console.WriteLine(Text.Instructions.Cart);
                    break;
            }
        }while (!EndCommand);
    }
    private static void HandleCurrencyCommand()
    {
        Console.WriteLine(Text.Instructions.Currency);
        do
        {
            CheckForBackCommand();
            switch (EndCommand)
            {
                case false when Enum.TryParse(UserInput?.ToUpper(), out Currency currency):
                    GildedRoseCustomer.PreferredCurrency = currency;
                    Console.WriteLine($"{Text.Messages.CurrencyChanged}{currency}");
                    break;
                case false:
                    Console.WriteLine(Text.Errors.InvalidInput);
                    break;
            }
        }while (!EndCommand);
    }
    private static void HandleDaysCommand()
    {
        if (GildedRoseCustomer.GetCartItems().Count > 0)
        {
            Console.WriteLine(
                "You must empty your cart before proceeding. Do you want to remove all items from your cart? (yes/No)");
            UserInput = Console.ReadLine();
            if (UserInput?.ToLower() != "yes")
            {
                return;
            }
            GildedRoseCustomer.RemoveAllItemsFromCart();
        }
        Console.WriteLine(Text.Instructions.Days);
        do
        {
            CheckForBackCommand();
            switch (EndCommand)
            {
                case false when int.TryParse(UserInput?.ToLower(), out var days):
                {
                    GildedRoseStore.Day += days;
                    for (var i = 0; i < days; i++)
                    {
                        GildedRoseStore.GetStoreItems().ForEach(x => x.UpdateItem());
                    }
                    Console.WriteLine($"{days} have passed.\nToday is day: {GildedRoseStore.Day}");
                    EndCommand = true;
                    break;
                }
                case false:
                    Console.WriteLine(Text.Errors.InvalidInput);
                    break;
            }
        } while (!EndCommand);
    }
    private static void HandleExitCommand()
    {
        Console.WriteLine(Text.Messages.Goodbye);
    }
    private static void HandleInvalidInput()
    {
        Console.WriteLine(Text.Errors.InvalidInput);
        Console.WriteLine(Text.Instructions.MainMenu);
    }
}