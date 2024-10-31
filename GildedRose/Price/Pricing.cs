using GildedRose.Items;

namespace GildedRose.Price;

public static class Pricing
{
    public static double ConvertPrice(Item item, string targetCurrency)
    {
        if(CurrencyConverter.GetCurrencies().FirstOrDefault(c => c == targetCurrency) == null)
        {
            throw new ArgumentException("Currency not supported.");
        }
        return CurrencyConverter.Convert(item.Price, targetCurrency);
    }
    
    public static double ApplyDiscount(Item item, double discount)
    {
        if(discount < 0 || discount > 1)
        {
            throw new ArgumentException("Discount must be between 0 and 1.");
        }
        return item.Price * (1 - discount);
    }
}