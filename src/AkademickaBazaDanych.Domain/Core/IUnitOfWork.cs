namespace AkademickaBazaDanych.Domain.Core;
public interface IUnitOfWork
{
    Task InTransaction(Func<Task> operation);
}
