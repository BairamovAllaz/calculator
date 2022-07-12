using System;
using System.Linq;

namespace Calculator.App;

public class Calc
{
    public string? Input { get; set; }

    public Calc() {}
    public Calc(string input)
    {
        Input = input;
    }

    public decimal GetResult()
    {
        char Operator = GetOperator();
        if (Operator == ' ')
        {
            return 0;
        }
        (decimal num1, decimal num2) nums = Parser(Operator);
        return DoCalc(nums.num1, nums.num2, Operator);
    }
    
    public decimal GetResult(char Operator)
    {
        (decimal num1, decimal num2) nums = Parser(Operator);
        return DoCalc(nums.num1, nums.num2, Operator);
    }
    
    private char GetOperator()
    {
        if (Input.Contains('+')) return '+';
        else if (Input.Contains('-')) return '-'; 
        else if (Input.Contains('/')) return '/'; 
        else if (Input.Contains('x')) return 'x';
        else return ' ';
    }

    public bool CheckOperator(string input)
    {
        char[] str = { '+', '-', '/', 'x' };
        return input.Any(str.Contains);
    }
    
    private decimal DoCalc(decimal num1,decimal num2,char Operator)
    {
        decimal result = 0;
        if (Operator == '+') result = num1 + num2;
        else if (Operator == '-') result = num1 - num2; 
        else if (Operator == '/') result = num1 / num2; 
        else if (Operator == 'x') result = num1 * num2;
        return result;
    }

    private (decimal, decimal) Parser(char Operator)
    {
        if (Input != null)
        {
            int index = Input.IndexOf(Operator, StringComparison.Ordinal);
            decimal num1 = Convert.ToDecimal(Input.Substring(0, index));
            decimal num2 = Convert.ToDecimal(Input.Substring(index + 1, Input.Length - index - 1));
            return (num1,num2);
        }
        return (0, 0);
    }
}