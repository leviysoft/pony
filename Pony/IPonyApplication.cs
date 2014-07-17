using StructureMap;

namespace Pony
{
    public interface IPonyApplication
    {
        IContainer Container { get; }
    }
}