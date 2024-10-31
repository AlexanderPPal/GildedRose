using GildedRose.Interfaces;
using GildedRose.UserInterface;

namespace GildedRose.Items;

public static class ItemList
{
    private static readonly IList<IItem> _storeItems = new List<IItem>()
    {
        new Sulfuras("Sulfuras", 10, 80, 1110, false),
        new AgedBrie("Aged Brie", 2, 0, 10, false),
        new BackstagePass("Backstagepass ", 15, 20, 30, false),
        new Item("Normal Item", 5, 10, 20, false),
    };

    private static readonly IList<IItem> _cartItems = new List<IItem>();
    
    public static void PrintItems()
    {
        foreach (var item in _storeItems)
        {
            Console.WriteLine($"Name: {item.Name}, SellIn: {item.SellIn}, Quality: {item.Quality}, Price: {item.GetPrice(Ui.UserCurrency)}");
        }
    }

    public static void AddItemToCart(string userInput)
    {
        var item = _storeItems.FirstOrDefault(i => i.Name == userInput);
        if (item != null)
        {
            _cartItems.Add(item);
            _storeItems.Remove(item);
            Console.WriteLine($"{item.Name} added to cart.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
    
    public static void PrintCart()
    {
        foreach (var item in _cartItems)
        {
            Console.WriteLine($"Name: {item.Name}, SellIn: {item.SellIn}, Quality: {item.Quality}, Price: {item.GetPrice(Ui.UserCurrency)}");
        }
    }

    public static void RemoveItemFromCart(string userInput)
    {
        var item = _cartItems.FirstOrDefault(i => i.Name == userInput);
        if (item != null)
        {
            _storeItems.Add(item);
            _cartItems.Remove(item);
            Console.WriteLine($"{item.Name} removed from cart.");
        }
        else
        {
            Console.WriteLine("Item not found.");
        }
    }
}