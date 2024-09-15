using System.Reflection;

namespace Shaura.OOP.Lab2;

public enum IsoCode
{
    US,
    CA,
    RU,
    DE
}

public struct Airport(IsoCode isoCode, string? localCode, string? name, double latitude, double longitude)
{
    public IsoCode IsoCode { get; set; } = isoCode;
    public string? LocalCode { get; set; } = localCode;
    public string? Name { get; set; } = name;
    public double Latitude = latitude;
    public double Longitude = longitude;

    public void ChangePosition(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public Airport Copy(IsoCode? isoCode, string? localCode, string? name, double? latitude, double? longitude)
    {
        return new Airport() with
        {
            IsoCode = isoCode ?? IsoCode,
            LocalCode = localCode ?? LocalCode,
            Name = name ?? Name,
            Latitude = latitude ?? Latitude,
            Longitude = longitude ?? Longitude
        };
    }
}

public class Map
{
    public double CurrentLatitude = 0;
    public double CurrentLongitude = 0;
    public List<Airport> Airports { get; set; }
    
    public Map()
    {
        Airports = [
            new Airport(IsoCode.US,
                "02OI",
                "Murtha Airport",
                41.801998138427734, -80.56539916992188),

            new Airport(IsoCode.RU,
                "SVO",
                "Sheremetyevo International Airport",
                55.972599, 37.4146),

            new Airport(IsoCode.CA,
                "CHB3",
                "Hope Bay Aerodrome",
                68.156, -106.618),

            new Airport(IsoCode.DE,
                "DE-0029",
                "Berlinchen Airfield",
                53.2251775192, 12.565526962299998)
        ];
    }
    
    public void ChangeCurrentPosition(double latitude, double longitude)
    {
        CurrentLatitude = latitude;
        CurrentLongitude = longitude;
    }

    public Airport? SearchAirport(string searchString)
    {
        return Airports.Find(airport => airport.LocalCode == searchString 
                                        || airport.Name == searchString 
                                        || airport.IsoCode.ToString() == searchString);
    }
}