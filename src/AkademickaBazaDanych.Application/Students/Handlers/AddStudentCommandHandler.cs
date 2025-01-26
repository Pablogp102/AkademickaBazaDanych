using AkademickaBazaDanych.Application.Core;
using AkademickaBazaDanych.Application.Students.Services;
using AkademickaBazaDanych.Contracts.Students.Commands;
using AkademickaBazaDanych.Contracts.Students.Results;
using AkademickaBazaDanych.Domain.Core;
using AkademickaBazaDanych.Domain.Students;

using MediatR;

namespace AkademickaBazaDanych.Application.Students.Handlers;

public sealed class AddStudentCommandHandler(
    IStudentService studentService,
    IIdGenerator idGenerator,
    IUnitOfWork unitOfWork) : IRequestHandler<AddStudentCommand, AddStudentResult>
{
    public async Task<AddStudentResult> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = Student.Create(
                        idGenerator.NewId(),
                        request.FirstName!,
                        request.LastName!,
                        Address.Create(request.Street!, request.City!, request.PostalCode!, request.Country!),
                        await studentService.GenerateNewIndex(),
                        Pesel.Create(request.PESEL!),
                        request.Gender.ToString());
        try
        {
            await unitOfWork.InTransaction(async () =>
            {
                await studentService.AddStudent(student);
            });
            return AddStudentResult.Success(student.Id);
        }
        catch (Exception ex)
        {
            return AddStudentResult.Failure($"An error occurred: {ex.Message}");
        }


    }
}

