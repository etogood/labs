using System.Text.Json;

namespace Shaura.OOP.Lab3.DataAccess;

public static class StudentsRepository
{
    public static void SaveToFile(string path, List<Student> students)
    {
        var jsonString = JsonSerializer.Serialize(students);
        File.WriteAllText(path, jsonString);
    }
    
    public static List<Student>? ReadFromFile(string path)
    {
        var jsonString = File.ReadAllText(path);
        var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
        return students;
    }
}