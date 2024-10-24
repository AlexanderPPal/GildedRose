namespace GildedRose.Items;

public class Item : GildedRose.Interfaces.IItem
{
    public string Name { get; }
    public int SellIn { get; set; }
    private int _quality;
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

    public Item(string name, int sellIn, int quality, double price)
    {
        Name = name;
        SellIn = sellIn;
        Quality = quality;
        Price = price;
    }

    private protected virtual void UpdateQuality()
    {
        if(SellIn < 0)
        {
            Quality -= 2;
        }
        else
        {
            Quality -= 1;
        }
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