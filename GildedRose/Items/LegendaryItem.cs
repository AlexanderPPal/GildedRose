namespace GildedRose.Items;

public class LegendaryItem(string name, int sellIn, int quality, double price, bool conjured)
    : Item(name, sellIn, quality, price, conjured);