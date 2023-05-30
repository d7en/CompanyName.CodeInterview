using Verivox.CodeInterview.Calculation;

namespace Verivox.CodeInterview.Tests.Calculation;

public class BasicElectricityTariffStrategyTests
{
    [Theory]
    [InlineData(3500, 830)]
    [InlineData(4500, 1050)]
    [InlineData(6000, 1380)]
    public void BasicElectricityTariffStrategy_ReturnsCorrectCost_ForBasicTariff(int consumptionInput, decimal expectedAnnualCosts)
    {
        var basicElectricityTariffStrategy = new BasicElectricityTariffCalculationStrategy(5, 0.22m);

        var actualAnnualCosts = basicElectricityTariffStrategy.CalculateAnnualCost(consumptionInput);

        Assert.Equal(expectedAnnualCosts, actualAnnualCosts);
    }
}
