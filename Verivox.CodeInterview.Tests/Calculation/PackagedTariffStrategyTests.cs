using Verivox.CodeInterview.Calculation;

namespace Verivox.CodeInterview.Tests.Calculation;

public class PackagedTariffStrategyTests
{
    [Theory]
    [InlineData(3500, 800)]
    [InlineData(4500, 950)]
    [InlineData(6000, 1400)]
    public void PackagedTariffStrategy_ReturnsCorrectCost_ForPackagedTariff(int consumptionInput, decimal expectedAnnualCosts)
    {
        var packagedTariffStrategy = new PackagedTariffCalculationStrategy(800, 4000, 0.3m);

        var actualAnnualCosts = packagedTariffStrategy.CalculateAnnualCost(consumptionInput);

        Assert.Equal(expectedAnnualCosts, actualAnnualCosts);
    }
}
