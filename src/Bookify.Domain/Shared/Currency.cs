namespace Bookify.Domain.Shared;

public sealed record Currency
{
    private static readonly Currency Usd = new("USD");
    private static readonly Currency Eur = new("EUR");
    internal static readonly Currency None = new("");
    private Currency(string code) => Code = code;
    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ?? 
               throw new Exception($"Unknown currency code: {code}");
    }
    
    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
       Usd,
       Eur
    };
}