namespace GildedRose.Items;

public class Sulfuras(string name, int sellIn, int quality, double price, bool conjured)
    : Item(name, sellIn, quality, price, conjured)
{
    public override void UpdateItem()
    {
        //do nothing
    }
}