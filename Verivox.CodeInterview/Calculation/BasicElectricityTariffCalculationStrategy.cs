namespace Verivox.CodeInterview.Calculation;

public class BasicElectricityTariffCalculationStrategy : ICalculationModelStrategy
{
    public decimal BaseCostsPerMonth { get; }
    public decimal ConsumptionCostsKwH { get; }

    public BasicElectricityTariffCalculationStrategy(decimal baseCostsPerMonth, decimal consumptionCostsKwH)
    {
        BaseCostsPerMonth = baseCostsPerMonth;
        ConsumptionCostsKwH = consumptionCostsKwH;
    }

    public decimal CalculateAnnualCost(int consumptionKwhYear)
    {
        int months = 12;
        return BaseCostsPerMonth * months + consumptionKwhYear * ConsumptionCostsKwH;
    }
}
