namespace AkademickaBazaDanych.Application.Core;
public interface IApplicationInitializer
{
    Task Initialize(CancellationToken cancellationToken = default);
}

