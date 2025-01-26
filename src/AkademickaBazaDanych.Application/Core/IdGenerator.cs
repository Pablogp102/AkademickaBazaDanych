namespace AkademickaBazaDanych.Application.Core;
internal class IdGenerator : IIdGenerator
{
    public Guid NewId()
       => SequentialGuid.SequentialGuidGenerator.Instance.NewGuid();
}

public interface IIdGenerator
{
    Guid NewId();
}

