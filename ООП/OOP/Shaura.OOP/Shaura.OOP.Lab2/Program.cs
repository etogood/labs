using Shaura.OOP.Lab2;

// Структуры Airport
var airport1 = new Airport( 
    IsoCode.US,
    "02OI",
    "Murtha Airport",
    41.801998138427734, -80.56539916992188);
var airport2 = new Airport(
    IsoCode.RU,
    "SVO",
    "Sheremetyevo International Airport",
    55.972599, 37.4146);

airport2.ChangePosition(30, 30);
airport1 = airport2; // присвоение значения
airport2.ChangePosition(40, 40); // airport1.Latitude = 30  и  airport1.Longitude = 30 по прежнему

Console.WriteLine("------------- Структуры -------------");
Console.WriteLine($"First Airport Location: {airport1.Latitude} lat., {airport1.Longitude} long.");     // 30, 30
Console.WriteLine($"Second Airport Location: {airport2.Latitude} lat., {airport2.Longitude} long.");    // 40, 40


var map1 = new Map();
var map2 = new Map();

map2.ChangeCurrentPosition(10, 10);
map1 = map2; // присвоение ссылки
map2.ChangeCurrentPosition(20, 20);   // теперь и map1.Latitude и map1.Longitude = 20,
                                                    // так как обе ссылки (map1 и map2)
                                                    // указывают на один объект в куче
Console.WriteLine();
Console.WriteLine("------------- Классы -------------");
Console.WriteLine($"First Map Location: {map1.CurrentLatitude} lat., {map1.CurrentLongitude} long.");   // 20, 20
Console.WriteLine($"Second Map Location: {map2.CurrentLatitude} lat., {map2.CurrentLongitude} long.");  // 20, 20

Console.WriteLine();
Console.WriteLine("------------- Payload -------------");       // Полезная нагрузка лаб. работы
Console.WriteLine(map1.SearchAirport("SVO")?.Name);   // Поиск аэропорта на карте по названию