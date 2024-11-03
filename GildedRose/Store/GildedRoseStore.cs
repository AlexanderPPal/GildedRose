using GildedRose.Customer;
using GildedRose.Interfaces;
using GildedRose.Items;

namespace GildedRose.Store;

public static class GildedRoseStore
{
    private static readonly List<IItem> StoreItems =
    [
        new Sulfuras("Sulfuras", 10, 80, 1110, false),
        new AgedBrie("Aged Brie", 2, 0, 10, false),
        new BackstagePass("Backstagepass", 15, 20, 30, false),
        new Item("Normal Item", 5, 10, 20, false)
    ];
    
    public static int Day {get; set;}
    
    public static void PrintStoreItems()
    {
        foreach (var item in StoreItems)
        {
            Console.WriteLine($"Name: {item.Name}, SellIn: {item.SellIn}, Quality: {item.Quality}, Price: {item.GetPrice(GildedRoseCustomer.PreferredCurrency)}");
        }
    }
    
    public static List<IItem> GetStoreItems()
    {
        return StoreItems;
    }
}