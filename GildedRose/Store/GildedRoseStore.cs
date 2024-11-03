using GildedRose.Customer;
using GildedRose.Interfaces;
using GildedRose.Items;

namespace GildedRose.Store;

public static class GildedRoseStore
{
    private static readonly List<IItem> StoreItems =
    [
        new LegendaryItem("Sulfuras", 10, 80, 100, false),
        new LegendaryItem("Sulfuras", 5, 80, 100, false),
        new AgedBrie("Aged Brie", 2, 0, 10, false),
        new AgedBrie("Aged Brie", 10, 20, 10, false),
        new BackstagePass("Backstage Pass", 15, 20, 30, false),
        new BackstagePass("Backstage Pass", 5, 49, 30, false),
        new Item("Normal Item", 5, 25, 20, false),
        new Item("Normal Item", 10, 30, 20, false),
        new Item("Normal Item", 0, 10, 20, false),
        new Item("Conjured Item", 3, 6, 15, true),
        new AgedBrie("Conjured Aged Brie", 5, 7, 15, true),
        new BackstagePass("Conjured Backstage Pass", 1, 8, 15, true)
    ];
    
    public static int Day {get; set;}
    
    public static void PrintStoreItems()
    {
        foreach (var item in StoreItems)
        {
            Console.WriteLine($"{nameof(item.Name)}: {item.Name}, {nameof(item.SellIn)}: {item.SellIn}, {nameof(item.Quality)}: {item.Quality}, {nameof(item.Price)}: {item.GetPrice(GildedRoseCustomer.PreferredCurrency)}, {nameof(item.Conjured)}: {item.Conjured}");
        }
    }
    
    public static List<IItem> GetStoreItems()
    {
        return StoreItems;
    }
}