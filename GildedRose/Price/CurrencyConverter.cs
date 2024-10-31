namespace GildedRose.Price;

public static class CurrencyConverter
{
    private static Dictionary<string, double> _exchangeRates = new Dictionary<string, double>
    {
        { "USD", 1.10 }, 
        { "GBP", 0.85 },
        { "JPY", 130.00 }
    };

    public static double Convert(double amount, string targetCurrency)
    {
        if (_exchangeRates.ContainsKey(targetCurrency))
        {
            return amount * _exchangeRates[targetCurrency];
        }
        throw new ArgumentException("Currency not supported.");
    }
    
    public static IReadOnlyCollection<string> GetCurrencies()
    {
        return _exchangeRates.Keys;
    }
}