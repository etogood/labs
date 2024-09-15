namespace Shaura.OOP.Lab3;

public interface IPerson
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
}

public class Student : IPerson
{
    private string _name = "EMPTY_NAME";
    private string _surname = "EMPTY_SURNAME";
    private int _age = 16;
    private double _avgScore = 2d;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Surname
    {
        get => _surname;
        set => _surname = value;
    }
    
    public int Age
    {
        get => _age;
        set
        {
            if (value < 1) return;
            _age = value;
        }
    }
    
    public double AvgScore
    {
        get => _avgScore;
        set
        {
            if (value < 1d) return;
            _avgScore = value;
        }
    }

    public Student(string name, string surname, int age, double avgScore)
    {
        Name = name;
        Surname = surname;
        Age = age;
        AvgScore = avgScore;
    }
}