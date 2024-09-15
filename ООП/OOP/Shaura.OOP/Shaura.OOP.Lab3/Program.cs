using Shaura.OOP.Lab3;
using Shaura.OOP.Lab3.DataAccess;

var uni = new University();
var student1 = new Student("John", "Doe", 18, 4.25);
IPerson person2 = new Student("Joe", "Dope", 20, 3.5); // абстракция (IPerson) не ограничивает реализацию (Student)

uni.Add(student1);
uni.Add((Student)person2); // реализация (University) ограничивает абстракцию (IPerson)

var list = uni.Get();

StudentsRepository.SaveToFile("./students.json", list);
var jsonList = StudentsRepository.ReadFromFile("./students.json");

if (jsonList != null) 
    foreach (var item in jsonList)
        Console.WriteLine($"{item.Surname} {item.Name}, {item.Age} : ср. балл = {item.AvgScore}");