using AkademickaBazaDanych.Application.Students.Services;
using AkademickaBazaDanych.Contracts.Students.Commands;
using AkademickaBazaDanych.Contracts.Students.Results;
using AkademickaBazaDanych.Domain.Core;

using MediatR;

namespace AkademickaBazaDanych.Application.Students.Handlers;
public sealed class RemoveStudentCommandHandler(
        IStudentService studentService,
        IUnitOfWork unitOfWork) : IRequestHandler<RemoveStudentCommand, RemoveStudentResult>
{
    public async Task<RemoveStudentResult> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await unitOfWork.InTransaction(async () =>
            {
                await studentService.RemoveStudent(request.IndexNumber ?? "");
            });

            return RemoveStudentResult.Success();
        }
        catch (Exception ex)
        {
            return RemoveStudentResult.Failure($"An error occurred: {ex.Message}");
        }
    }

}


