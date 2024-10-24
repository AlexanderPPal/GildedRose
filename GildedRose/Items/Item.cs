using GildedRose.Interfaces;

namespace GildedRose.Items;

public class Item : IItem
{
    private int _quality;

    protected Item(string name, int sellIn, int quality, double price, bool conjured)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
        Price = price;
        Conjured = conjured;
    }

    public string Name { get; }
    public int SellIn { get; set; }

    public int Quality
    {
        get => _quality;
        private protected set
        {
            _quality = value switch
            {
                < 0 => 0,
                > 50 => 50,
                _ => value
            };
        }
    }

    public double Price { get; set; }
    public bool Conjured { get; }

    private protected virtual void UpdateQuality()
    {
        var valueToSubtract = SellIn < 0 ? 2 : 1;
        Quality -= Conjured ? valueToSubtract * 2 : valueToSubtract;
    }

    private void UpdateSellIn()
    {
        SellIn -= 1;
    }

    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    public virtual void UpdateItem()
    {
        UpdateQuality();
        UpdateSellIn();
    }
}