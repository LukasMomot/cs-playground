namespace CsPlayground.Utils;

public class ConsoleUtils
{
    public static void WriteLineWithColor(string text, ConsoleColor color)
    {
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = oldColor;
    }
}