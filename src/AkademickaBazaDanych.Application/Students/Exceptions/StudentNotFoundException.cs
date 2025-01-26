using AkademickaBazaDanych.Domain.Students;

namespace AkademickaBazaDanych.Application.Students.Exceptions;
public class StudentLastNameNotFoundException : Exception
{
    public StudentLastNameNotFoundException(string lastName) : base($"Student with last name {lastName} was not found.")
    {

    }
}

public class StudentPESELNotFoundException : Exception
{
    public StudentPESELNotFoundException(string PESEL) : base($"Student with PESEL {PESEL} was not found.")
    {

    }
}

public class StudentIdNotFoundException : Exception
{
    public StudentIdNotFoundException(Guid id) : base($"Student with id {id} was not found.")
    {

    }
}
public class StudentIndexNumberNotFoundException : Exception
{
    public StudentIndexNumberNotFoundException(string indexNumber) : base($"Student with index number {indexNumber} was not found.")
    {

    }
}