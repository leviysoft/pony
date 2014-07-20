using System.Globalization;
using Pony.Serialization;

namespace PonyMvc.Demo.Serialization
{
    public class IntSerializer : ISerializer<int>
    {
        public string Serialize(int instance)
        {
            return instance.ToString(CultureInfo.InvariantCulture);
        }

        public int Deserialize(string representation)
        {
            return int.Parse(representation, CultureInfo.InvariantCulture);
        }
    }
}
