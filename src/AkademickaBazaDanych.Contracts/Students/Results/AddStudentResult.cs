using AkademickaBazaDanych.Contracts.Students.Results;

namespace AkademickaBazaDanych.Contracts.Students.Results;
public class AddStudentResult : BaseResult
{
    public Guid? StudentId { get; private set; }

    private AddStudentResult(bool isSuccess, Guid? studentId = null, string? errorMessage = null)
        : base(isSuccess, errorMessage)
    {
        StudentId = studentId;
    }

    public static AddStudentResult Success(Guid? studentId = null)
        => new AddStudentResult(true, studentId);

    public static AddStudentResult Failure(string errorMessage)
        => new AddStudentResult(false, errorMessage: errorMessage);
}


