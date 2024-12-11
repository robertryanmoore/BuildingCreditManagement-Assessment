using System.Text.Json;
using BuildingCreditManagement_Assessment;

Console.WriteLine("BUILDING CREDIT MANAGENMT");

List<Customer> customerList = new List<Customer>
            {
                new Customer
                {
                    CustomerId = 1,
                    Name = "Alice",
                    PaymentHistory = 90,
                    CreditUtilization = 40,
                    AgeOfCreditHistory = 5
                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Bob",
                    PaymentHistory = 70,
                    CreditUtilization = 90,
                    AgeOfCreditHistory = 15
                },
                new Customer
                {
                    CustomerId = 3,
                    Name = "Charlie",
                    PaymentHistory = 60,
                    CreditUtilization = 30,
                    AgeOfCreditHistory = 2
                }
            };

Console.WriteLine("---------------------------------------------------------");


string jsonStr = "[";


for (int i = 0; i < customerList.Count; i++)
{
    var customer = customerList[i];

    Console.WriteLine(customer.Name);
    Console.WriteLine(customer.PaymentHistory);
    Console.WriteLine(customer.CreditUtilization);
    Console.WriteLine(customer.AgeOfCreditHistory);

    int score = 0;

    try
    {
        score = CalculateCreditScore(customer);
        Console.WriteLine(score);

        if (score < 0)
            score = 0;

        if (score > 50)
            Console.WriteLine("Low Risk");
        else
            Console.WriteLine("High Risk");
    }
    catch (Exception)
    {
        Console.WriteLine("Unable to calculate credit score");
    }

    var customerWithScore = new
    {
        customer.CustomerId,
        customer.Name,
        customer.PaymentHistory,
        customer.CreditUtilization,
        customer.AgeOfCreditHistory,
        CreditScore = score
    };


    jsonStr += JsonSerializer.Serialize(customerWithScore, new JsonSerializerOptions { WriteIndented = true });

    if (i < customerList.Count - 1)
        jsonStr += ",";

    Console.WriteLine("---------------------------------------------------------");
}

jsonStr += "]";

string filePath = "CustomerData.json";
try
{
    File.WriteAllText(filePath, jsonStr);
    Console.WriteLine($"JSON data has been saved to {filePath}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
}


static int CalculateCreditScore(Customer cust)
{
    double creditScore = (0.4 * cust.PaymentHistory) + (0.3 * (100-cust.CreditUtilization)) + (0.3 * Math.Min(cust.AgeOfCreditHistory,10)); //CreditScore = (0.4 _ PaymentHistory) + (0.3 _ (100 - CreditUtilization)) + (0.3 \* Min(AgeOfCreditHistory, 10))**
    
    return (int)creditScore;
}