using Pony.DI;
using StructureMap;

namespace Pony.StructureMap
{
    public sealed class StructureMapPonyContainer : IPonyContainer
    {
        private readonly IContainer _container;

        public StructureMapPonyContainer(IContainer container)
        {
            _container = container;
        }

        public void Register<T, TInst>() where TInst : T
        {
            _container.Configure(cfg => cfg.For<T>().Use<TInst>());
        }

        public void RegisterInstance<T>(T instance) where T : class
        {
            _container.Configure(cfg => cfg.For<T>().Use(instance));
        }

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }

        public T TryGetInstance<T>()
        {
            return _container.TryGetInstance<T>();
        }
    }
}
