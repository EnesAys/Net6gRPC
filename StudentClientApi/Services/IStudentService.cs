using StudentClientApi.Models;

namespace StudentClientApi.Services;

public interface IStudentService
{
    Task<string> InsertStudentsAsync(StudentReq request);
}