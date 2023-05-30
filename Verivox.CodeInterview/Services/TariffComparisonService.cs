using Verivox.CodeInterview.Calculation;
using Verivox.CodeInterview.Domain;

namespace Verivox.CodeInterview.Services;

public class TariffComparisonService : ITariffComparisonService
{
    private readonly ICalculationModelStrategy basicElectricityTariffStrategy;
    private readonly ICalculationModelStrategy packagedTariffStrategy;

    public TariffComparisonService(ICalculationModelStrategy basicElectricityTariffStrategy, ICalculationModelStrategy packagedTariffStrategy)
    {
        this.basicElectricityTariffStrategy = basicElectricityTariffStrategy;
        this.packagedTariffStrategy = packagedTariffStrategy;
    }

    public IEnumerable<Product> MakeConsumption(int consumptionKwhYear)
    {
        var productA = new Product(WellKnownProductNames.ProductA_Name, basicElectricityTariffStrategy.CalculateAnnualCost(consumptionKwhYear));
        var productB = new Product(WellKnownProductNames.ProductB_Name, packagedTariffStrategy.CalculateAnnualCost(consumptionKwhYear));

        var tariffs = new List<Product>
        {
            productA,
            productB,
        };

        return tariffs.OrderBy(x => x.AnnualCosts);
    }
}
