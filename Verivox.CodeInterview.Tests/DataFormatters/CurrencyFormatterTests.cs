using Verivox.CodeInterview.DataFormatters;

namespace Verivox.CodeInterview.Tests.Services;

public class CurrencyFormatterTests
{
    private readonly ICurrencyFormatter currencyFormatter;

    public CurrencyFormatterTests()
    {
        currencyFormatter = CurrencyFormatter.EuroFormatter;
    }

    [Theory]
    [InlineData(830, "830,00 €")]
    [InlineData(1050, "1.050,00 €")]
    public void CurrencyFormatter_ReturnsCorrectStringAmountRepresentation_ForTheory(decimal amount, string expectedFormattedAmount)
    {
        var formattedAmount = currencyFormatter.FormatAmount(amount);
        Assert.Equal(formattedAmount, expectedFormattedAmount);
    }
}