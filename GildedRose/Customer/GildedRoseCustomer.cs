using GildedRose.Interfaces;
using GildedRose.Price;
using GildedRose.Store;
using GildedRose.UserInterface;

namespace GildedRose.Customer;

public static class GildedRoseCustomer
{
    public static Currency PreferredCurrency { get; set; } = Currency.EUR;
    private static readonly List<IItem> CartItems = [];
    
    public static List<IItem> GetCartItems()
    {
        return CartItems;
    }
    
    public static void PrintCartItems()
    {
        foreach (var item in CartItems)
        {
            Console.WriteLine($"Name: {item.Name}, SellIn: {item.SellIn}, Quality: {item.Quality}, Price: {item.GetPrice(PreferredCurrency)}");
        }
        var totalPrice = CartItems.Sum(i => i.GetPrice(PreferredCurrency));
        totalPrice= Discount.GetDiscountedPrice(totalPrice,CartItems);
        Console.WriteLine($"Total price: {totalPrice} {PreferredCurrency}");
    }
    
    public static void AddItemToCart(string userInput)
    {
        var item = GildedRoseStore.GetStoreItems().Find(i => i.Name.ToLower().Equals(userInput.ToLower()));
        if (item != null)
        {
            CartItems.Add(item);
            GildedRoseStore.GetStoreItems().Remove(item);
            Console.WriteLine($"{item.Name} added to cart.");
        }
        else
        {
            Console.WriteLine(Text.Errors.ItemNotFound);
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
            Console.WriteLine(Text.Errors.ItemNotFound);
        }
    }
    
    public static void RemoveAllItemsFromCart()
    {
        foreach (var item in CartItems)
        {
            GildedRoseStore.GetStoreItems().Add(item);
        }
        CartItems.Clear();
        Console.WriteLine("All items removed from cart.");
    }
}