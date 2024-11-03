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
                > 50 when GetType().Name != nameof(LegendaryItem) => 50,
                _ => value
            };
        }
    }

    public double Price { get; private set; }
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
    
    public void SetPrice(double price, Currency currency)
    {
        Price = CurrencyConverter.Convert(price, fromCurrency: currency);
    }
    
    public double GetPrice(Currency currency)
    {
        return CurrencyConverter.Convert(Price, toCurrency: currency);
    }

    public void UpdateItem()
    {
        if (GetType().Name == nameof(LegendaryItem)) return;
        UpdateQuality();
        UpdateSellIn();
    }
}