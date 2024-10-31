using GildedRose.Price;

namespace GildedRose.Interfaces;

public interface IItem
{
    string Name { get; }
    int SellIn { get; set; }
    int Quality { get; }
    bool Conjured { get; }
    void UpdateItem();
    void SetPrice(double price, Currency currency);
    double GetPrice(Currency currency);
}