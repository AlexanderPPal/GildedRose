namespace GildedRose.Items;

public class BackstagePass : Item
{
    public BackstagePass(string name, int sellIn, int quality, double price)
        : base(name, sellIn, quality, price)
    {
    }

    
    private protected override void UpdateQuality()
    {
        switch (SellIn)
        {
            case < 0:
                Quality += 2;
                break;
            case <= 5:
                Quality += 3;
                break;
            case <= 10:
                Quality = 0;
                break;
            default:
                Quality += 1;
                break;
        }
    }
    
}