using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CalculatorProgram;

public class StringCalculator
{
    public int Calculate(string args)
    {
        if (string.IsNullOrEmpty(args)) return 0;

        var delimiters = new List<string> { ",", "\n" };

        if (args.StartsWith("//"))
        {
            var lines = args.Split("\n");

            var delimiterLine = lines[0].Replace("//", "").Trim();

            if (delimiterLine.StartsWith("[") && delimiterLine.EndsWith("]"))
            {
                delimiters = delimiterLine
                    .Trim('[', ']')  
                    .Split("][")     
                    .ToList();
            }
            else
            {
                delimiters = new List<string> { delimiterLine };
            }

            args = string.Join("\n", lines.Skip(1));
        }

        var numbers = args.Split(delimiters.ToArray(), StringSplitOptions.None)
            .Select(int.Parse)
            .ToList();

        var negatives = numbers.Where(n => n < 0).ToList();
        if (negatives.Any())
        {
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
        }

        return numbers.Where(n => n <= 1000).Sum();
    }
}

