namespace GildedRose.Price;
public static class CurrencyConverter
{
    private const string DefaultCurrency = "EUR";
    private static readonly Dictionary<string, double> ExchangeRates = new Dictionary<string, double>
    {
        { "USD", 1.10 },
        { "GBP", 0.85 },
        { "JPY", 130.00 },
        { "EUR", 1.00 },
    };

    public static double Convert(double amount, string fromCurrency = DefaultCurrency, string toCurrency = DefaultCurrency)
    {
        if (!ExchangeRates.TryGetValue(fromCurrency, out var fromRate) || !ExchangeRates.TryGetValue(toCurrency, out var toRate))
        {
            throw new ArgumentException("Currency not supported.");
        }

        var amountInEur = amount / fromRate;
        return amountInEur * toRate;
    }

    public static IEnumerable<string> GetCurrencies()
    {
        return ExchangeRates.Keys;
    }
}