using AkademickaBazaDanych.Application.Students.Exceptions;
using AkademickaBazaDanych.Contracts.Students.Enums;
using AkademickaBazaDanych.Domain.Students;
using AkademickaBazaDanych.Infrastructure.Db;

using Microsoft.EntityFrameworkCore;

using System.Linq;
namespace AkademickaBazaDanych.Infrastructure.Studnets;

public class StudentRepository : IStudentRepository
{
    private readonly DbSet<Student> _set;

    public StudentRepository(AcademicDbContext academicDbContext)
    {
        _set = academicDbContext.Set<Student>();
    }

    public async Task<Student> Add(Student student)
        => (await _set.AddAsync(student)).Entity;

    public async Task<IEnumerable<Student>> GetAll()
    {
        var query = _set.AsNoTracking();
        return await query.ToListAsync();
    }
    
    public async Task<Student?> GetById(Guid id)
        => await _set.FirstOrDefaultAsync(s => s.Id == id) 
        ?? throw new ArgumentNullException(nameof(id));
    public async Task<IEnumerable<Student?>> GetByLastName(string lastName)
        => await _set.AsNoTracking().Where(s => s.LastName == lastName).ToListAsync()
        ?? throw new StudentLastNameNotFoundException(lastName);

    public async Task<IEnumerable<Student?>> GetByPESEL(string? peselPart)
    {
        var  students = await _set.AsNoTracking().ToListAsync();
        
        return students.Where(s => s.PESEL!.Value.Contains(peselPart!)).ToList() ?? Enumerable.Empty<Student>();
    }

    public async Task<Student?> GetByIndexNumber(string indexNumber)
        => await _set.FirstOrDefaultAsync(s => s.IndexNumber!.Value == indexNumber) 
        ?? throw new ArgumentNullException(nameof(indexNumber));
    public async Task<IEnumerable<Student?>> SortByPESEL()
        => await _set.OrderBy(s => s.PESEL).ToListAsync();

    public async Task<IEnumerable<Student>> SortByLastName()
        => await _set.OrderBy(s => s.LastName).ToListAsync();

    public async Task<bool> Remove(string indexNumber) 
        => !string.IsNullOrWhiteSpace(indexNumber) 
        && (await _set.FirstOrDefaultAsync(x => x.IndexNumber!.Value == indexNumber)) is { } student 
        && _set.Remove(student) != null;

    public async Task<IEnumerable<string>> GetAllIndexNumbers() 
        => (await _set.ToListAsync())
           .Select(s => s!.IndexNumber!.Value)
           .OrderBy(x => x);

}

