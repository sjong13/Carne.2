namespace Carne.Interfaces
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
