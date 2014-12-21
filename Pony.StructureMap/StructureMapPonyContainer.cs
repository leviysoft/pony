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
