namespace Verivox.CodeInterview;


public class TariffComparison
{
    public IEnumerable<ProductBase> MakeConsumption(int consumption)
    {
        var basicElectricityTariffStrategy = new BasicElectricityTariffCalculationStrategy(5, 0.22m);
        var packagedTariffStrategy = new PackagedTariffCalculationStrategy(800, 4000, 0.3m);

        var productA = new ProductA
        {
            Name = "basic electricity tariff",
            AnnualCosts = basicElectricityTariffStrategy.CalculateAnnualCost(consumption),
        };


        var productB = new ProductB
        {
            Name = "Packaged tariff"
        };
        productB.CalculationModelStrategy = packagedTariffStrategy;
        productB.CalculateAnnualCosts(consumption);


        var tariffs = new List<ProductBase>
        {
            productA,
            productB,
        };

        return tariffs.OrderBy(x => x.AnnualCosts);
    }
}

public abstract class ProductBase
{
    public string Name { get; set; }
    public decimal AnnualCosts { get; set; }

    public ICalculationModelStrategy? CalculationModelStrategy { get; set; }

    public void CalculateAnnualCosts(int consumption)
    {
        ArgumentNullException.ThrowIfNull(CalculationModelStrategy);
        AnnualCosts = CalculationModelStrategy.CalculateAnnualCost(consumption);
    }
}


public class ProductA : ProductBase
{
}

public class ProductB : ProductBase
{
}

public interface ICalculationModelStrategy
{
    decimal CalculateAnnualCost(int consumptionPerYear);
}

public class BasicElectricityTariffCalculationStrategy : ICalculationModelStrategy
{
    public BasicElectricityTariffCalculationStrategy(decimal baseCostsPerMonth, decimal consumptionCostsKwH)
    {
        BaseCostsPerMonth = baseCostsPerMonth;
        ConsumptionCostsKwH = consumptionCostsKwH;
    }

    public decimal BaseCostsPerMonth { get; }
    public decimal ConsumptionCostsKwH { get; }

    public decimal CalculateAnnualCost(int consumptionPerYear)
    {
        int months = 12;
        return BaseCostsPerMonth * months + consumptionPerYear * ConsumptionCostsKwH;
    }
}

public class PackagedTariffCalculationStrategy : ICalculationModelStrategy
{
    public PackagedTariffCalculationStrategy(decimal minFixedCostPerYear, decimal topLimitKwH, decimal extraConsumptionCostsKwH)
    {
        MinFixedCostPerYear = minFixedCostPerYear;
        TopLimitKwH = topLimitKwH;
        ExtraConsumptionCostsKwH = extraConsumptionCostsKwH;
    }

    public decimal MinFixedCostPerYear { get; }
    public decimal TopLimitKwH { get; }
    public decimal ExtraConsumptionCostsKwH { get; }

    public decimal CalculateAnnualCost(int consumptionPerYear)
    {
        if (consumptionPerYear <= TopLimitKwH)
            return MinFixedCostPerYear;

        return MinFixedCostPerYear + (consumptionPerYear - TopLimitKwH) * ExtraConsumptionCostsKwH;
    }
}