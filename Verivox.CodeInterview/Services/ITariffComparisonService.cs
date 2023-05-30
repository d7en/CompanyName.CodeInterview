using Verivox.CodeInterview.Domain;

namespace Verivox.CodeInterview.Services;

public interface ITariffComparisonService
{
    IEnumerable<Product> MakeConsumption(int consumptionKwhYear);
}