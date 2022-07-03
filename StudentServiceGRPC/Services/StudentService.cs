using Grpc.Core;

namespace StudentServiceGRPC.Services;

public class StudentService : StudentGRPCService.StudentGRPCServiceBase
{
    private readonly ILogger<StudentService> _logger;
    public StudentService(ILogger<StudentService> logger)
    {
        _logger = logger;
    }

    public override async Task<StudentResponse> AddStudentStream(IAsyncStreamReader<StudentRequest> requestStream, ServerCallContext context)
    {
        var result = new StudentResponse();
        var count = 0;
        await foreach (var student in requestStream.ReadAllAsync())
        {
            var message = $"{student.StudentId} - {student.Name} added.";
            result.Message += message;
            Console.WriteLine(message);
            count++;
        }
        Console.WriteLine($"Add students stream has been ended. Count : {count}");

        return result;
    }
}
