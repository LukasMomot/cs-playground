
using CsPlayground;
// Static imports
using static System.Console;

WriteLine("Hello, World!");

var dr = Manager.GetUberDriver(30);
var dr2 = Manager.GetUberDriver(110);
var dr3 = Manager.GetUberDriver(100);
var dr4 = Manager.GetUberDriver(10);

if (dr is { Duration: > 30 and < 50} ) 
{
    WriteLine("Pattern match in IF and you dont need to return anything. Cool 😎");
}

// Alternative VAR Pattern
if (dr is { Duration: var d} && d is > 30 and < 50 ) 
{
    WriteLine("Pattern match in IF and you dont need to return anything. Cool 😎");
}


var p1 = CalculatePrice(dr);
var p2 = CalculatePrice(dr2);

var dr3Price = CalculatePrice2(dr3);

var priceTest = dr3Price with { Value = 200 };

var dop1 = DecideOnPrice(dr);
var dop2 = DecideOnPrice(dr2);
var dop3 = DecideOnPrice(dr4);
WriteLine($"Price of drive 1: {p1.Name}  {p1.Price}");
WriteLine($"Price of drive 2: {p2.Name}  {p2.Price}");
WriteLine($"Price of drive 3: {(dr3 as UberDrive)?.DriverName}  {dr3Price.Value}");
WriteLine($"Price of Test drive : Test Drive  {priceTest.Value}");
WriteLine($"Decide on Price 1: {dop1}");
WriteLine($"Decide on Price 2: {dop2}");
WriteLine($"Decide on Price 3: {dop3}");

DeconstructPlayground();
RangesPlaygroud();
RawStringLiteralsPlayground("""My "parameter" is here""");

//await Consumer();

#region Declarations

// ===== DEFINITIONS
void DeconstructPlayground()
{
    Person person = new()
    {
        Name = "Suraj",
        Surname = "Prscho"
    };

    var (p1Name, p1Surname) = person;
    WriteLine($"Object after Deconstruct: {p1Name} {p1Surname}");
}
void RawStringLiteralsPlayground(string param)
{
    var longMessage = $$"""
    This is the param {{ param }}
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them.
    """;
    
    WriteLine(longMessage);
}

string DecideOnPrice(Drive dr1)
{
    // Pattern matching on tuples
    var (price, company) = CalculatePrice(dr1);

    var random = 2;
    var result = (price, company) switch
    {
        { price: < 20 } obj when obj.company.StartsWith("Yus")  => "Yufu po taniosci",
        (> 20 and < 100, _) when random == 3 => "Mega tanio",
        (> 100, _) => "Drogo",
        _ => "Normalnie"
    };

    return result;
}

(decimal Price, string Name) CalculatePrice(Drive drive)
{
    // Pattern Matching
    var price = drive switch
    {
        UberDrive { Duration: < 20 } => (drive.Duration, "Yusuf"),
        UberDrive { Duration: > 20 and < 120 } ud => (ud.Duration * 1.5m, "Uber"),
        UberDrive ud => (ud.Duration * 2, "Uber"),
        _ => (100, "Uber")
    };
    return price;
}

void RangesPlaygroud()
{
    // Ranges
    var lista = new[]
    {
        "hello",
        "world",
        "twoja",
        "stara"
    };

    // Start: 0 based; End: 1 based
    var l1 = lista[..2]; // hello world
    var l2 = lista[^1]; // "stara"
    var l3 = lista[1..3]; // world twoja

    // WriteLine("..2 => 2 first elements");
    // WriteLine(l1.Length);
    // WriteLine("^ => last element");
    // WriteLine(l2);
}

void ListPatternMatching()
{
    var arr = new[]
    {
        new Person("Don", "Test"),
        new Person("Sylverster", "Stalone")
    };

    if (arr is [_, var p])
    {
        WriteLine(p.Name);
    }
    
    
    var c = arr is [_, var b];
}

Price CalculatePrice2(Drive drive)
{
    // Tuples
    var (p, _) = CalculatePrice(drive);

    return new(p, Currency.Pln);
}

// ==== ASYNC Streams =========
async IAsyncEnumerable<int> Producer()
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(3000);
        yield return i;
    }
}

async Task Consumer()
{
    await foreach (int n in Producer())
    {
        WriteLine($"Producer created: {n}");
    }
    
    WriteLine("Producer is ready 🚀");
}

// ==============

// Anonymous function
var callback = (string result, int counter) => result + counter;
var res = callback("A", 2);

string Callback2(string result, int counter) => result + counter;
var res2 = Callback2("A", 2);

#endregion

#region C# 12 Features

var primary = new PrimaryConstruction(2, 2);
var prSum = primary.Sum();

WriteLine($"Primary construction: {prSum}");


#endregion


