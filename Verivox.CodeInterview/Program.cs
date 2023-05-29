using Verivox.CodeInterview;

Console.ForegroundColor = ConsoleColor.Green;

var tariffComparison = new TariffComparison();

var testCaseConsumptions = new[] { 3500, 4500, 6000 };

for (int i = 0; i < testCaseConsumptions.Length; i++)
{
    int testCase1Consumption = testCaseConsumptions[i];
    Console.WriteLine($"Test case #{i+1}, consumption: {testCase1Consumption}");
    foreach (var products in tariffComparison.MakeConsumption(testCase1Consumption))
    {
        Console.WriteLine($"{products.Name,-30}\t{products.AnnualCosts}");
    }
    Console.WriteLine();
}


Console.WriteLine();
Console.WriteLine("--------------------");

Console.ReadLine();
