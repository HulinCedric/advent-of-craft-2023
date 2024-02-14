using static System.Environment;
using static System.Globalization.CultureInfo;
using static System.String;

namespace Day09.Accountability;

public class Client(IReadOnlyDictionary<string, double> orderLines)
{
    public string ToStatement()
        => $"{FormatLines()}{NewLine}{FormatTotal()}";

    private string FormatLines()
        => Join(
            NewLine,
            orderLines
                .Select(kvp => FormatLine(kvp.Key, kvp.Value))
                .ToList());

    private static string FormatLine(string name, double value)
        => $"{name} for {value.ToString(InvariantCulture)}€";

    private string FormatTotal()
        => $"Total : {TotalAmount().ToString(InvariantCulture)}€";

    public double TotalAmount()
        => orderLines.Values.Sum();
}