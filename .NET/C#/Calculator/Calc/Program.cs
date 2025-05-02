using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("1. Basic Calculator");
        Console.WriteLine("2. Advanced Calculator");
        Console.WriteLine("3. Factorial Calculator");
        Console.Write("Operation Type : ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                BasicCalculator();
                break;
            case "2":
                AdvancedCalculator();
                break;
            case "3":
                FactorialCalculator();
                break;
            default:
                Console.WriteLine("pilih salah satu..");
                break;
        }
    }

    public static void BasicCalculator()
    {
        Console.WriteLine("Basic Calculator selected.");
        BasicCalc basicCalc = new BasicCalc();

        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());
        
        Console.Write("Enter operation (+, -, *, /): ");
        string operation = Console.ReadLine();

        double? result = basicCalc.PerformBasicOperation(num1, num2, operation);
        if (result.HasValue)
        {
            Console.WriteLine($"Result: {result.Value}");
        }
    }

    public static void AdvancedCalculator()
    {
        Console.WriteLine("Advanced Calculator selected.");
        AdvancedCalc advancedCalc = new AdvancedCalc();

        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter second number (optional, press Enter to skip): ");

        string num2Input = Console.ReadLine();
        double? num2 = string.IsNullOrEmpty(num2Input) ? (double?)null : Convert.ToDouble(num2Input);
        Console.Write("Enter operation (sqrt or pow): ");

        string operation = Console.ReadLine();
        double? result = advancedCalc.PerformAdvancedOperation(num1, num2, operation);

        if (result.HasValue)
        {
            Console.WriteLine($"Result: {result.Value}");
        }
    }

    public static void FactorialCalculator()
    {
        Console.WriteLine("Factorial Calculator selected.");
        FactorialCalc factorialCalc = new FactorialCalc();

        Console.Write("Enter number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        double? result = factorialCalc.CalculateFactorial(num1);

        if (result.HasValue)
        {
            Console.WriteLine($"Result: {result.Value}");
        }
    }
}