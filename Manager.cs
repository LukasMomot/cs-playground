namespace CsPlayground;

public static class Manager
{
    public static Drive GetUberDriver(decimal duration) {
        var drive = new UberDrive
        {
            DriverName = "Yusuf",
            Duration = duration
        };
        return drive;
    }
}

public abstract class Drive
{
    public decimal Duration { get; init; }

    public string Destination { get; set; }
}

public class UberDrive : Drive
{
    public required string DriverName { get; set; }
}

public class BusDrive : Drive
{
    public int? LineNumber { get; set; }
}

public class Person
{
    public Person()
    {
    }
    
    public Person(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }


    public void Deconstruct(out string name, out string surname)
    {
        name = Name;
        surname = Surname;
    }

    public string Name { get; init; }

    public string Surname { get; init; }
    
}

