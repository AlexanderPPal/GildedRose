namespace GildedRose.Interfaces;

public interface IItem
{
    string Name { get; }
    int SellIn { get; }
    int Quality { get; }
    double Price { get; }
}