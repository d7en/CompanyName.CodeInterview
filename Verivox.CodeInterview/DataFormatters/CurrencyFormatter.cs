using System.Globalization;

namespace Verivox.CodeInterview.DataFormatters;

public class CurrencyFormatter : ICurrencyFormatter
{
    public static readonly CurrencyFormatter EuroFormatter = new CurrencyFormatter(CultureInfo.GetCultureInfo("de-DE"));


    private readonly CultureInfo cultureInfo;

    public CurrencyFormatter(CultureInfo cultureInfo)
    {
        this.cultureInfo = cultureInfo;
    }

    public string FormatAmount(decimal amount)
    {
        return amount.ToString("C", cultureInfo);
    }
}
