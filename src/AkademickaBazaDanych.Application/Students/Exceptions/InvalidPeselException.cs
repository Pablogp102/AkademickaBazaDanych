namespace AkademickaBazaDanych.Application.Students.Exceptions;
public class InvalidPeselException : Exception
{
    public InvalidPeselException(string PESEL) : base($"Invalid PESEL: {PESEL}")
    {

    }
}

