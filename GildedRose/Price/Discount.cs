using GildedRose.Interfaces;
using GildedRose.Store;
using GildedRose.UserInterface;

namespace GildedRose.Price;

public static class Discount
{
    public static double GetDiscountedPrice(double totalPrice, IReadOnlyCollection<IItem> cartItems)
    {
        if(GildedRoseStore.Day %5 == 0)
        {
            totalPrice *= 0.8;
            Console.WriteLine($"20{Text.Messages.DiscountApplied}");
        } else if (cartItems.Count >= 3)
        {
            totalPrice *= 0.9;
            Console.WriteLine($"10{Text.Messages.DiscountApplied}");
        }
        return totalPrice;
    }
}