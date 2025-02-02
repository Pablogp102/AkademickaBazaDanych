using AkademickaBazaDanych.Application.Students.Exceptions;
using AkademickaBazaDanych.Contracts.Students.DTOs;
using AkademickaBazaDanych.Contracts.Students.Enums;
using AkademickaBazaDanych.Domain.Students;

namespace AkademickaBazaDanych.Application.Students.Services;
public interface IStudentService
{
    Task<Student> AddStudent(Student student);
    Task<IEnumerable<StudentDTO>> GetAllStudents(string? searchTerm, SortingOptions? sortBy, bool isAscending, int pageNumber, int pageSize);
    Task<Student> GetStudentById(Guid id);
    Task<IEnumerable<StudentDetailsDTO>> GetStudentsByLastName(string lastName);
    Task<IEnumerable<StudentDetailsDTO>> GetStudentsByPESEL(string PeselPart);
    Task<Student> GetStudentByIndexNumber(string IndexNumber);
    Task<IEnumerable<StudentDTO>> GetSortedStudentsByPESEL();
    Task<IEnumerable<StudentDTO>> GetSortedStudentsByLastName();
    Task<bool> RemoveStudent(string indexNumber);
    Task<IndexNumber> GenerateNewIndex();
}

public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public async Task<Student> AddStudent(Student student)
    {
        if (student is null)
        {
            throw new ArgumentNullException(nameof(student));
        }
        return await studentRepository.Add(student);
    }
    public async Task<IEnumerable<StudentDTO>> GetAllStudents(
    string? searchTerm,
    SortingOptions? sortBy,
    bool isAscending,
    int pageNumber,
    int pageSize)
    {
        var studentsQuery = await studentRepository.GetAll();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            studentsQuery = studentsQuery.Where(s =>
                s.LastName!.StartsWith(searchTerm) ||
                s.PESEL!.Value.StartsWith(searchTerm)
            );
        }

        var studentsList = studentsQuery.ToList();

        if (sortBy != null)
        {
            if (sortBy == SortingOptions.LastName)
            {
                studentsList = isAscending
                    ? studentsList.OrderBy(s => s.LastName ?? string.Empty).ToList()
                    : studentsList.OrderByDescending(s => s.LastName ?? string.Empty).ToList();
            }
            else if (sortBy == SortingOptions.PESEL)
            {
                studentsList = isAscending
                    ? studentsList.OrderBy(s => s.PESEL?.ToString() ?? string.Empty).ToList()
                    : studentsList.OrderByDescending(s => s.PESEL?.ToString() ?? string.Empty).ToList();
            }
        }

        var pagedStudents = studentsList
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

        var studentsDTO = pagedStudents
            .Select(s => new StudentDTO(
                s.FirstName!,   
                s.LastName!,
                s.PESEL?.ToString() ?? string.Empty,  
                s.IndexNumber?.ToString() ?? string.Empty
            ));

        return studentsDTO;
    }


    public async Task<Student> GetStudentById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(id));
        }
        return await studentRepository.GetById(id) ?? throw new StudentIdNotFoundException(id);
    }
    public async Task<IEnumerable<StudentDetailsDTO>> GetStudentsByPESEL(string peselPart)
    {
        if (string.IsNullOrWhiteSpace(peselPart))
            throw new ArgumentNullException(nameof(peselPart));

        var students = await studentRepository.GetByPESEL(peselPart)
            ?? throw new StudentPESELNotFoundException(peselPart);
        

        return students.Select(student => 
        {
            Gender? gender = MapGender(student);

            return new StudentDetailsDTO(
                student!.FirstName!,
                student.LastName!,
                student.PESEL!.Value.ToString(),
                student.IndexNumber!.Value.ToString(),
                student.Address!.ToString(),
                gender
            );
        }) ?? Enumerable.Empty<StudentDetailsDTO>();
    }

    public async Task<IEnumerable<StudentDetailsDTO>> GetStudentsByLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException(nameof(lastName));
        }

        var students = await studentRepository.GetByLastName(lastName)
            ?? throw new StudentLastNameNotFoundException(lastName);

        return students.Select(student =>
        {
            Gender? gender = MapGender(student);

            return new StudentDetailsDTO(
                student!.FirstName!,
                student.LastName!,
                student.PESEL!.Value.ToString(),
                student.IndexNumber!.Value.ToString(),
                student.Address!.ToString(),
                gender
            );
        });
    }


    public async Task<Student> GetStudentByIndexNumber(string IndexNumber)
    {
        if (string.IsNullOrWhiteSpace(IndexNumber))
        {
            throw new ArgumentNullException(nameof(IndexNumber));
        }
        return await studentRepository.GetByIndexNumber(IndexNumber) ?? throw new ArgumentNullException(nameof(IndexNumber));
    }

    public async Task<IEnumerable<StudentDTO>> GetSortedStudentsByPESEL()
    {
        var students = await studentRepository.SortByPESEL();

        return students.Select(s => new StudentDTO(
            s!.FirstName!,
            s!.LastName!,
            s!.PESEL!.Value.ToString(),
            s.IndexNumber!.Value.ToString()
        )) ?? Enumerable.Empty<StudentDTO>();
    }

    public async Task<IEnumerable<StudentDTO>> GetSortedStudentsByLastName()
    {
        var students = await studentRepository.SortByLastName();

        return students.Select(s => new StudentDTO(
            s.FirstName!,
            s.LastName!,
            s!.PESEL!.Value.ToString(),
            s.IndexNumber!.Value.ToString()
        )) ?? Enumerable.Empty<StudentDTO>();
    }
  
    public async Task<bool> RemoveStudent(string indexNumber)
    {
        if (string.IsNullOrWhiteSpace(indexNumber))
        {
            throw new ArgumentNullException(nameof(indexNumber));
        }
        return await studentRepository.Remove(indexNumber);  
    }

    public async Task<IndexNumber> GenerateNewIndex()
    {
        var takenIndexNumbers = await studentRepository.GetAllIndexNumbers();

        return IndexNumber.CreateNew(takenIndexNumbers);
    }
    private static Gender? MapGender(Student? student)
    {
        return Enum.TryParse<Gender>(student!.Gender, out var parsedGender)
                                     ? parsedGender
                                     : throw new InvalidGenderException(student.Gender!);
    }
}

