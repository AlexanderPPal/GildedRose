using GildedRose.Interfaces;
using GildedRose.Price;

namespace GildedRose.Items;

public class Item : IItem
{
    private int _quality;

    public Item(string name, int sellIn, int quality, double price, bool conjured)
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

    private double Price;
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
    
    public void SetPrice(double price, string currency)
    {
        Price = CurrencyConverter.Convert(price, fromCurrency: currency);
    }
    
    public double GetPrice(string currency)
    {
        return CurrencyConverter.Convert(Price, toCurrency: currency);
    }

    public virtual void UpdateItem()
    {
        UpdateQuality();
        UpdateSellIn();
    }
}