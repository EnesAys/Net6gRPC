namespace StudentClientApi.Models;

public class StudentReq
{
    public IAsyncEnumerable<Student> Students { get; set; }
}

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; }
}
