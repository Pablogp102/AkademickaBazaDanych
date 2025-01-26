using AkademickaBazaDanych.Contracts.Students.Enums;

namespace AkademickaBazaDanych.Application.Students.Exceptions;

public class InvalidGenderException : Exception
{
    public InvalidGenderException(string gender) : base($"Unable to map this gender: {gender}")
    {

    }
}


