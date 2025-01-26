namespace AkademickaBazaDanych.Contracts.Students.Results;

public class RemoveStudentResult : BaseResult
{
    private RemoveStudentResult(bool isSuccess, string? errorMessage = null)
        : base(isSuccess, errorMessage)
    {

    }
    public static RemoveStudentResult Success()
    => new RemoveStudentResult(true);

    public static RemoveStudentResult Failure(string errorMessage)
        => new RemoveStudentResult(false, errorMessage);
}

