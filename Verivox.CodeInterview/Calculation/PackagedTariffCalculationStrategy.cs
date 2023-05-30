namespace Verivox.CodeInterview.Calculation;

public class PackagedTariffCalculationStrategy : ICalculationModelStrategy
{
    public decimal MinFixedCostPerYear { get; }
    public decimal TopLimitKwH { get; }
    public decimal ExtraConsumptionCostsKwH { get; }

    public PackagedTariffCalculationStrategy(decimal minFixedCostPerYear, decimal topLimitKwH, decimal extraConsumptionCostsKwH)
    {
        MinFixedCostPerYear = minFixedCostPerYear;
        TopLimitKwH = topLimitKwH;
        ExtraConsumptionCostsKwH = extraConsumptionCostsKwH;
    }

    public decimal CalculateAnnualCost(int consumptionKwhYear)
    {
        if (consumptionKwhYear <= TopLimitKwH)
            return MinFixedCostPerYear;

        return MinFixedCostPerYear + (consumptionKwhYear - TopLimitKwH) * ExtraConsumptionCostsKwH;
    }
}