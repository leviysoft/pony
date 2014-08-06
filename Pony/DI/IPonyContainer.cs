namespace Pony.DI
{
    public interface IPonyContainer
    {
        void Register<T, TInst>() where TInst: T;
        void RegisterInstance<T>(T instance) where T : class;
        T GetInstance<T>();
        T TryGetInstance<T>();
    }
}
