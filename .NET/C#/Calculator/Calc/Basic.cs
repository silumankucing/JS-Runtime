using System;

public class BasicCalc
{
    public double? PerformBasicOperation(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                if (num2 != 0)
                {
                    return num1 / num2;
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return null;
                }
            default:
                Console.WriteLine("Error: Invalid operation.");
                return null;
        }
    }
}
