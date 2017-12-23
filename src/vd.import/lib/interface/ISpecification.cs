namespace vd.import.lib.Interface
{
    public interface ISpecification<T>
    {
         bool IsSatisfiedBy(T o);
    }
}