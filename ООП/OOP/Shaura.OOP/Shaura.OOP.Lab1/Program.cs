Person John = new("John"); // Вызов конструктора с 1 аргументом имени
Person Will = new("Will", 20); // Вызов конструктора с 2 аргументами имени и возраста
Person Bob = new("", 21, "bob2000@gmail.com"); // Вызов конструктора с 3 аргументами (имя по умолчанию = Bill, возраст и email)

Console.WriteLine("---------------------- John ----------------------------");

Console.WriteLine(John.name); // John
Console.WriteLine(John.age); // 18 (default)
Console.WriteLine(John.email); // ben@gmail.com (default)

Console.WriteLine("---------------------- Will ----------------------------");

Console.WriteLine(Will.name); // Will
Console.WriteLine(Will.age); // 20
Console.WriteLine(Will.email); // ben@gmail.com (default)

Console.WriteLine("---------------------- Bob ----------------------------");

Console.WriteLine(Bob.name); // Bob (default)
Console.WriteLine(Bob.age); // 21
Console.WriteLine(Bob.email); // bob2000@gmail.com
