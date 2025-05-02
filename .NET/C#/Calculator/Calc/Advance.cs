using System;

public class AdvancedCalc
{
    public double? PerformAdvancedOperation(double num1, double? num2, string operation)
    {
        switch (operation)
        {
            case "sqrt":
                if (num1 >= 0)
                {
                    return Math.Sqrt(num1);
                }
                else
                {
                    Console.WriteLine("Error: Square root of a negative number is not allowed.");
                    return null;
                }
            case "pow":
                if (num2.HasValue)
                {
                    return Math.Pow(num1, num2.Value);
                }
                else
                {
                    Console.WriteLine("Error: Second number is required for power operation.");
                    return null;
                }
            case "mod":
                if (num2.HasValue && num2.Value != 0)
                {
                    return num1 % num2.Value;
                }
                else
                {
                    Console.WriteLine("Error: Modulus by zero is not allowed.");
                    return null;
                }
            default:
                return null;
        }
    }
}
