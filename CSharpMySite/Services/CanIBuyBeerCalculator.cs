using Microsoft.AspNetCore.Connections.Features;

namespace CSharpMySite.Services;


public enum Location
{
    Krogen,
    Systemet
}
public class CanIBuyBeerCalculator
{
    public bool CanIBuyBeer(Location location, int age, float promille)
    {
        if(promille > 1.0) return false;

        if(location == Location.Krogen && age < 18)
            return false;
        if (location == Location.Systemet && age < 20)
            return false;
        return true;
    }
}