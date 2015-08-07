<Query Kind="Program" />

void Main()
{
    Func<string, Name> parseName = ImperativeParseName;

    parseName("").Dump();
    parseName("Carlos").Dump();
    parseName("Carlos Norris").Dump();
    parseName("Carlos Ray Norris").Dump();
    parseName("Carlos Ray 'Chuck' Norris").Dump();
}

public class Name
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; } 
    public string Surname { get; set; }
}

public Name ImperativeParseName(string name)
{
    var names = name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    
    var splitName = new Name();
    
    //Imperative conditional code
    if (names.Length >= 1)
        splitName.FirstName = names[0]; //Side effecting!
    
    if (names.Length >= 2)
        splitName.Surname = names[names.Length - 1];
    
    if (names.Length >= 3)
    {
        //Side effects, manual string building
        var stringBuilder = new StringBuilder();
        for (int i = 1; i < names.Length - 1; i++)
            stringBuilder.AppendFormat("{0} ", names[i]);
        
        splitName.MiddleName = stringBuilder.ToString().Trim();
    }
    
    return splitName;
}

public Name FunctionalParseName(string name)
{
    var names = name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    
    //No side effects
    return new Name 
    {
        FirstName = names.FirstOrDefault(), //Declare what we want, rather than how
        MiddleName = names.Length >= 3 //Ternary expressions
            ? names
                .Skip(1)
                .Take(names.Length - 2)
                .Aggregate("", (a, b) => string.Format("{0} {1}", a, b))
                .Trim() //A bit icky
            : null,
        Surname = names.Length > 1
            ? names.Last()
            : null,
    };
}

public Name BetterFunctionalParseName(string name)
{
    var names = name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    return new Name 
    {
        FirstName = names.FirstOrDefault(),
        MiddleName = names.Length >= 3
            ? String.Join(" ", names //Hard to read
                .Skip(1)
                .Take(names.Length - 2))
            : null,
        Surname = names.Length > 1
            ? names.Last()
            : null,
    };
}

public Name BestFunctionalParseName(string name)
{
    var names = name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    return new Name 
    {
        FirstName = names.FirstOrDefault(),
        MiddleName = names.Length >= 3
            ? names
                .Skip(1)
                .Take(names.Length - 2)
                .StringJoin(" ") //Much better
            : null,
        Surname = names.Length > 1
            ? names.Last()
            : null,
    };
}

public static class FunctionalExtensions
{
    public static string StringJoin(this IEnumerable<string> strings, string separator)
    {
        return String.Join(separator, strings);
    }
}