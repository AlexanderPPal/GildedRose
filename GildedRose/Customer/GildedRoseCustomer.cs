using GildedRose.Interfaces;
using GildedRose.Price;
using GildedRose.Store;

namespace GildedRose.Customer;

public static class GildedRoseCustomer
{
    public static Currency PreferredCurrency { get; set; } = Currency.EUR;
    private static readonly List<IItem> CartItems = [];
    
    public static void PrintCartItems()
    {
        foreach (var item in CartItems)
        {
            Console.WriteLine($"Name: {item.Name}, SellIn: {item.SellIn}, Quality: {item.Quality}, Price: {item.GetPrice(PreferredCurrency)}");
        }
    }
    
    public static void AddItemToCart(string userInput)
    {
        var item = GildedRoseStore.GetStoreItems().FirstOrDefault(i => i.Name == userInput);
        if (item != null)
        {
            CartItems.Add(item);
            GildedRoseStore.GetStoreItems().Remove(item);
            Console.WriteLine($"{item.Name} added to cart.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
    
    public static void RemoveItemFromCart(string userInput)
    {
        var item = CartItems.Find(i => i.Name == userInput);
        if (item != null)
        {
            GildedRoseStore.GetStoreItems().Add(item);
            CartItems.Remove(item);
            Console.WriteLine($"{item.Name} removed from cart.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
}