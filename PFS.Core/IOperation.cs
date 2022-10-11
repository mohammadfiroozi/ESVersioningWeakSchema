using Newtonsoft.Json.Linq;

namespace PFS.Core
{
    public interface IOperation
    {
        JObject Execute(JObject json);
    }

    public class DefaultValue : IOperation
    {
        private readonly string _value;
        private readonly string _key;
        public DefaultValue(string key , string value)
        {
            _value = value;
            _key = key;     
        }
        public JObject Execute(JObject json)
        {
            json[_key] = _value;
            return json;     
        }
    }
}   