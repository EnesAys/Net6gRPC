using StudentClientApi.Models;

namespace StudentClientApi.Services;

public class StudentService : IStudentService
{
    private readonly StudentGRPCService.StudentGRPCServiceClient _studentGRPCServiceClient;
    public StudentService(StudentGRPCService.StudentGRPCServiceClient studentGRPCServiceClient)
    {
        _studentGRPCServiceClient = studentGRPCServiceClient;
    }
    public async Task<string> InsertStudentsAsync(StudentReq request)
    {
        using var addStudentStream = _studentGRPCServiceClient.AddStudentStream();
        await foreach (Student student in request.Students)
        {
            StudentRequest studentRequest = new()
            {
                StudentId = student.StudentId,
                Name = student.Name
            };

            await addStudentStream.RequestStream.WriteAsync(studentRequest);
        }

        await addStudentStream.RequestStream.CompleteAsync();

        StudentResponse response = await addStudentStream;

        return response.Message;
    }
        public async Task<StudentListResponse> GetStudentsAsync()
    {
        var response = new StudentListResponse{Students = new List<string>()};
        var getStudentStream = _studentGRPCServiceClient.GetStudentList(new StudentListRequest());
        foreach(var student in getStudentStream.Students)   
        {
            response.Students.Add(student.Message);
        }

        return response;
    }
}