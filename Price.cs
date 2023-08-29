namespace CsPlayground;

public enum Currency
{
    Pln = 1,
    Dollar = 2,
    Euro = 3
};
public record Price(decimal Value, Currency Currency);