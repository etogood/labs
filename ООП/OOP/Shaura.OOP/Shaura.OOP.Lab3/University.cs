namespace Shaura.OOP.Lab3;

public interface IPeopleUnity<T> where T : IPerson
{
    public void Add(T person);
    public void Remove(T person);
    public List<T> Search(string searchQuery);
    public List<T> Get();
}

public class University : IPeopleUnity<Student>
{
    private readonly List<Student> _students = [];

    public void Add(Student person)
    {
        _students.Add(person);
    }
    
    public void Remove(Student person)
    {
        _students.Remove(person);
    }
    
    public List<Student> Search(string searchQuery)
    {
        return _students.FindAll(student => student.Name.Contains(searchQuery) ||
                                  student.Surname.Contains(searchQuery));
    }

    public List<Student> Get()
    {
        return _students;
    }
}