using Verivox.CodeInterview.Calculation;
using Verivox.CodeInterview.DataFormatters;
using Verivox.CodeInterview.Services;

Console.ForegroundColor = ConsoleColor.Green;

// Let's define dependencies (calculation strategies, currency formatters etc.) 
// in the real world we should use some DI container to manage dependencies
var basicElectricityTariffStrategy = new BasicElectricityTariffCalculationStrategy(5, 0.22m); // these values should be read from the Configuration
var packagedTariffStrategy = new PackagedTariffCalculationStrategy(800, 4000, 0.3m); // these values should be read from the Configuration
var currencyFormatter = CurrencyFormatter.EuroFormatter;

ITariffComparisonService tariffComparison = new TariffComparisonService(basicElectricityTariffStrategy, packagedTariffStrategy); // pass dependencies

// Some basic testing setup
var testCaseConsumptions = new[] { 3500, 4500, 6000 };

for (int i = 0; i < testCaseConsumptions.Length; i++)
{
    int testCase1Consumption = testCaseConsumptions[i];
    Console.WriteLine($"Test case #{i+1}, consumption: {testCase1Consumption}");
    foreach (var products in tariffComparison.MakeConsumption(testCase1Consumption))
    {
        Console.WriteLine($"{products.Name,-30}\t{currencyFormatter.FormatAmount(products.AnnualCosts)}");
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Done");

Console.ReadLine();
