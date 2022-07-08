using System.Collections.Generic;
using System.Linq;
using System.Windows.Markup;

namespace Calculator.App;

public static class Calc
{
    public static List<string> ParseString(string input)
    {
        char[] separators = {'-', '+','X','/'};
        List<string> subs = input.Split(separators).ToList();
        return subs;
    }
}