namespace GildedRose.Items;

public class AgedBrie(string name, int sellIn, int quality, double price)
    : Item(name, sellIn, quality, price)
{
    private protected override void UpdateQuality()
    {
        Quality += 1;
    }
}