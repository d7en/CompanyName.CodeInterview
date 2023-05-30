namespace Verivox.CodeInterview.Domain;

public class Product
{
    public string Name { get; private set; }
    public decimal AnnualCosts { get; private set; }

    public Product(string name, decimal annualCosts)
    {
        Name = name;
        AnnualCosts = annualCosts;
    }
}
