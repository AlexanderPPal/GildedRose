namespace GildedRose.Price;
public static class CurrencyConverter
{
    private const Currency DefaultCurrency = Currency.EUR;
    private static readonly Dictionary<Currency, double> ExchangeRates = new()
    {
        { Currency.USD, 1.10 },
        { Currency.GBP, 0.85 },
        { Currency.JPY, 130.00 },
        { Currency.EUR, 1.00 },
    };

    public static double Convert(double amount, Currency fromCurrency = DefaultCurrency, Currency toCurrency = DefaultCurrency)
    {
        if (!ExchangeRates.TryGetValue(fromCurrency, out var fromRate) || !ExchangeRates.TryGetValue(toCurrency, out var toRate))
        {
            throw new ArgumentException("Currency not supported.");
        }

        var amountInEur = amount / fromRate;
        return amountInEur * toRate;
    }

    public static IEnumerable<Currency> GetCurrencies()
    {
        return ExchangeRates.Keys;
    }
}