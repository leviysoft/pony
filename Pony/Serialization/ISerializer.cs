namespace Pony.Serialization
{
    public interface ISerializer<T>
    {
        string Serialize(T instance);
        T Deserialize(string representation);
    }
}
