namespace Invoices.Common.Interfaces
{
    public interface IApplyChanges<T>
    {
        T ApplyChanges(T entity);
    }
}
