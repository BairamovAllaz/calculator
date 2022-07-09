using System;
namespace Calculator.App;

public class Calc
{
    public string? Input { get; set; }

    public Calc() {}
    public Calc(string input)
    {
        Input = input;
    }

    public int GetResult()
    {
        char Operator = GetOperator();
        if (Operator == ' ')
        {
            return 0;
        }
        (int num1, int num2) nums = Parser(Operator);
        return DoCalc(nums.num1, nums.num2, Operator);
    }
    
    public int GetResult(char Operator)
    {
        (int num1, int num2) nums = Parser(Operator);
        return DoCalc(nums.num1, nums.num2, Operator);
    }

    public bool IsFirst(string input)
    {
        Input = input;
        if (GetOperator() == ' ') return true;
        return false;
    }

    private char GetOperator()
    {
        if (Input.Contains('+')) return '+';
        else if (Input.Contains('-')) return '-'; 
        else if (Input.Contains('/')) return '/'; 
        else if (Input.Contains('x')) return 'x';
        else return ' ';
    }
    
    private int DoCalc(int num1,int num2,char Operator)
    {
        int result = 0;
        if (Operator == '+') result = num1 + num2;
        else if (Operator == '-') result = num1 - num2; 
        else if (Operator == '/') result = num1 / num2; 
        else if (Operator == 'x') result = num1 * num2;
        return result;
    }

    private (int, int) Parser(char Operator)
    {
        if (Input != null)
        {
            int index = Input.IndexOf(Operator, StringComparison.Ordinal);
            int num1 = Convert.ToInt32(Input.Substring(0, index));
            int num2 = Convert.ToInt32(Input.Substring(index + 1, Input.Length - index - 1));
            return (num1,num2);
        }
        else
        {
            return (0, 0);
        }
    }
}