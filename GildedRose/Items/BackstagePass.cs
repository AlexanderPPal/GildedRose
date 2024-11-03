namespace GildedRose.Items;

public class BackstagePass(string name, int sellIn, int quality, double price, bool conjured)
    : Item(name, sellIn, quality, price, conjured)
{
    private protected override void UpdateQuality()
    {
        switch (SellIn)
        {
            case < 0:
                Quality = 0;
                break;
            case <= 5:
                Quality += 3;
                break;
            case <= 10:
                Quality += 2;
                break;
            default:
                Quality += 1;
                break;
        }
    }
}