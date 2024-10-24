namespace GildedRose.Items;

public class AgedBrie(string name, int sellIn, int quality, double price, bool conjured)
    : Item(name, sellIn, quality, price, conjured)
{
    private protected override void UpdateQuality()
    {
        Quality += 1;
    }
}