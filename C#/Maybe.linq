<Query Kind="Program" />

void Main()
{
    var application = new ApplicationDetails();
    
    string suburb = "Unknown";
    if (application.IdentityDetails != null && 
        application.IdentityDetails.Address != null)
        suburb = application.IdentityDetails.Address.Suburb;


#region FP version

    var suburb2 = application.IdentityDetails
        .Maybe(d => d.Address)
        .Maybe(a => a.Suburb) 
        ?? "Unknown";
        
#endregion

      
#region C# 6

    var suburb3 = application.IdentityDetails?.Address?.Suburb ?? "Unknown";
    
#endregion


#region Imperative Transform

    string isApartmentYesNo = "Unknown";
    if (application.IdentityDetails != null && 
        application.IdentityDetails.Address != null)
    {
        if (application.IdentityDetails.Address.IsApartment)
            isApartmentYesNo = "Yes";
        else
            isApartmentYesNo = "No";
    }
        
#endregion


#region FP Transform

    var isApartmentYesNo2 = application.IdentityDetails?.Address
        .Maybe(a => a.IsApartment ? "Yes" : "No") 
        ?? "Unknown";

#endregion

}

public static class FunctionalExtensions
{
    public static TReturn Maybe<T, TReturn>(this T obj, Func<T, TReturn> func)
        where T : class
    {
        return obj != null
            ? func(obj) 
            : default(TReturn);
    }

    public static TReturn Maybe<T, TReturn>(this T? obj, Func<T, TReturn> func)
        where T : struct
    {
        return obj.HasValue
            ? func(obj.Value)
            : default(TReturn);
    }
}

public class ApplicationDetails
{
    public IdentityDetails IdentityDetails { get; set; }
    // ...
}

public class IdentityDetails
{
    public Address Address { get; set; }
    // ...
}

public class Address
{
    public string Suburb { get; set; }
    public bool IsApartment { get; set; }
    // ...
}