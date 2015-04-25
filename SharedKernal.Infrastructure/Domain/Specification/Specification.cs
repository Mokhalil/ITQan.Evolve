namespace SharedKernal.Infrastructure.Domain.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
}
