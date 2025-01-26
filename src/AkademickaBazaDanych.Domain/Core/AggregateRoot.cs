namespace AkademickaBazaDanych.Domain.Core
{

    public interface IAggregateRoot
    {

    }
    public abstract class AggregateRoot<TIdentifier> : IAggregateRoot
    {
        public TIdentifier Id { get; protected init; }

        protected AggregateRoot(TIdentifier id)
        {
            Id = id;
        }
    }
}
