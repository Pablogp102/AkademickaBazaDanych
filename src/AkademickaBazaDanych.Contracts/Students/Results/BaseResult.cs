namespace AkademickaBazaDanych.Contracts.Students.Results;
public class BaseResult
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }

    protected BaseResult(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }
}
