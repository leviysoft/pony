namespace Pony.Serialization
{
    public class StringSerializationStub : ISerializer<string>
    {
        public string Serialize(string instance)
        {
            return instance;
        }

        public string Deserialize(string representation)
        {
            return representation;
        }
    }
}
