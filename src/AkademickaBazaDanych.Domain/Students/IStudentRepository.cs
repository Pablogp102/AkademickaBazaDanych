namespace AkademickaBazaDanych.Domain.Students;

public interface IStudentRepository
{
    Task<Student> Add(Student student);
    Task<IEnumerable<Student>> GetAll();
    Task<Student> GetById(Guid id);
    Task<IEnumerable<Student?>> GetByLastName(string lastName);
    Task<IEnumerable<Student?>> GetByPESEL(string? PeselPart);
    Task<Student?> GetByIndexNumber(string indexNumber);
    Task<IEnumerable<Student?>> SortByPESEL();
    Task<IEnumerable<Student>> SortByLastName();
    Task<bool> Remove(string indexNumber);
    Task<IEnumerable<string>> GetAllIndexNumbers();
}
