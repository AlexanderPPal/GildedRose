﻿using GildedRose.Customer;
using GildedRose.Price;
using GildedRose.Store;

namespace GildedRose.UserInterface;

public static class Ui
{
    public static string? UserInput { get; private set; }

    public static void HandleUserInput()
    {
        UserInput = Console.ReadLine();
        switch (UserInput)
        {
            case "list":
                GildedRoseStore.PrintStoreItems();
                Console.WriteLine(Text.Instructions.List);
                while (UserInput != "back")
                {
                    UserInput = Console.ReadLine();
                    if (UserInput != "back")
                    {
                        if (UserInput != null)
                        {
                            GildedRoseCustomer.AddItemToCart(UserInput);
                        }
                        else
                        {
                            Console.WriteLine(Text.Instructions.List);
                        }
                    }
                }
                break;
            case "cart":
                GildedRoseCustomer.PrintCartItems();
                Console.WriteLine(Text.Instructions.Cart);
                while (UserInput != "back")
                {
                    UserInput = Console.ReadLine();
                    if (UserInput != "back")
                    {
                        if (UserInput != null)
                        {
                            GildedRoseCustomer.RemoveItemFromCart(UserInput);
                        }
                        else
                        {
                            Console.WriteLine(Text.Instructions.Cart);
                        }
                    }
                }
                break;
            case "currency":
                Console.WriteLine(Text.Instructions.Currency);
                while (UserInput != "back")
                {
                    UserInput = Console.ReadLine();
                    if (UserInput != "back")
                    {
                        if (Enum.TryParse(UserInput, out Currency currency))
                        {
                            GildedRoseCustomer.PreferredCurrency = currency;
                        }
                        else
                        {
                            Console.WriteLine(Text.Errors.InvalidInput);
                        }
                    }
                }
                break;
            case "exit":
                Console.WriteLine(Text.Messages.Goodbye);
                break;
            default:
                Console.WriteLine(Text.Errors.InvalidInput);
                Console.WriteLine(Text.Instructions.MainMenu);
                break;
        }
    }
}