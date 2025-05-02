using System;

public class FactorialCalc
{
    public double? CalculateFactorial(double num)
    {
        if (num < 0)
        {
            Console.WriteLine("Error: Factorial of a negative number is not defined.");
            return null;
        }
        else if (num == 0 || num == 1)
        {
            return 1;
        }
        else
        {
            double result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}