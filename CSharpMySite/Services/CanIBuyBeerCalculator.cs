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
        if(location == Location.Krogen && age > 17 && promille < 1.0)
            return true;
        if (location == Location.Systemet && age > 17 && promille < 1.0)
            return true;
        return false;
    }
}