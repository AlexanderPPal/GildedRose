using GildedRose.Price;

namespace GildedRose.Interfaces;

public interface IItem
{
    string Name { get; }
    int SellIn { get; set; }
    int Quality { get; }
    bool Conjured { get; }
    double Price { get; }
    void UpdateItem();
    double GetPrice(Currency currency);
}