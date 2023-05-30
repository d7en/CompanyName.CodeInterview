using Verivox.CodeInterview.Calculation;
using Verivox.CodeInterview.Domain;
using Verivox.CodeInterview.Services;

namespace Verivox.CodeInterview.Tests.Services;

/// <summary>
/// T1_T2_T3
/// T1 = Unit
/// T2 = Scenario
/// T3 = Expected behavior
/// AAA, Act -> Arrange -> Assert
/// </summary>
public class TariffComparisonServiceTests
{
    private readonly ICalculationModelStrategy basicElectricityTariffStrategy;
    private readonly ICalculationModelStrategy packagedTariffStrategy;

    private readonly ITariffComparisonService tariffComparisonService;

    public TariffComparisonServiceTests()
    {
        basicElectricityTariffStrategy = new BasicElectricityTariffCalculationStrategy(5, 0.22m);
        packagedTariffStrategy = new PackagedTariffCalculationStrategy(800, 4000, 0.3m);

        tariffComparisonService = new TariffComparisonService(basicElectricityTariffStrategy, packagedTariffStrategy);
    }

    [Fact]
    public void TariffComparisonService_ReturnsProductB_WhenConsumptionIs3500()
    {
        var products = tariffComparisonService.MakeConsumption(3500);
        Assert.Equal(products.First().Name, WellKnownProductNames.ProductB_Name);
    }

    [Fact]
    public void TariffComparisonService_ReturnsProductB_WhenConsumptionIs4500()
    {
        var products = tariffComparisonService.MakeConsumption(4500);
        Assert.Equal(products.First().Name, WellKnownProductNames.ProductB_Name);
    }

    [Fact]
    public void TariffComparisonService_ReturnsProductA_WhenConsumptionIs6000()
    {
        var products = tariffComparisonService.MakeConsumption(6000);
        Assert.Equal(products.First().Name, WellKnownProductNames.ProductA_Name);
    }
}