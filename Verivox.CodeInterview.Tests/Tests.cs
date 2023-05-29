namespace Verivox.CodeInterview.Tests;

/// <summary>
/// T1_T2_T3
/// T1 = Unit
/// T2 = Scenario
/// T3 = Expected behavior
/// </summary>
public class BasicElectricityTariffStrategyTests
{
    [Theory]
    [InlineData(3500, 830)]
    [InlineData(4500, 1050)]
    [InlineData(6000, 1380)]
    public void BasicElectricityTariffStrategy(int consumptionInput, decimal expectedAnnualCosts)
    {
        var basicElectricityTariffStrategy = new BasicElectricityTariffCalculationStrategy(5, 0.22m);

        var actualAnnualCosts = basicElectricityTariffStrategy.CalculateAnnualCost(consumptionInput);

        Assert.Equal(expectedAnnualCosts, actualAnnualCosts);
    }
}

public class PackagedTariffStrategyTests
{
    [Theory]
    [InlineData(3500, 800)]
    [InlineData(4500, 950)]
    [InlineData(6000, 1400)]
    public void PackagedTariffStrategy(int consumptionInput, decimal expectedAnnualCosts)
    {
        var packagedTariffStrategy = new PackagedTariffCalculationStrategy(800, 4000, 0.3m);

        var actualAnnualCosts = packagedTariffStrategy.CalculateAnnualCost(consumptionInput);

        Assert.Equal(expectedAnnualCosts, actualAnnualCosts);
    }
}


public class TariffComparisonTests
{
    [Fact]
    public void TariffComparisonTest1()
    {
        var tariffComparison = new TariffComparison();

        var products = tariffComparison.MakeConsumption(3500);

        Assert.True(products.First().GetType() == typeof(ProductB));
    }

    [Fact]
    public void TariffComparisonTest2()
    {
        var tariffComparison = new TariffComparison();

        var products = tariffComparison.MakeConsumption(4500);

        Assert.True(products.First().GetType() == typeof(ProductB));
    }

    [Fact]
    public void TariffComparisonTest3()
    {
        var tariffComparison = new TariffComparison();

        var products = tariffComparison.MakeConsumption(6000);

        Assert.True(products.First().GetType() == typeof(ProductA));
    }
}