namespace Pony.DI
{
    public interface IPonyContainer
    {
        T GetInstance<T>();
        T TryGetInstance<T>();
    }
}
