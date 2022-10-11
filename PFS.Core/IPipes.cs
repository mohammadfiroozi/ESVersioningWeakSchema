using Newtonsoft.Json.Linq;

namespace PFS.Core
{
    public  interface IPipes
    {
        bool IsConfirmed(JObject json);
    }

    public class AbsentKey : IPipes
    {
        private readonly string _key;
        public AbsentKey(string key)
        {
            _key = key;
        }

        public bool IsConfirmed(JObject json)
        {
            return !json.ContainsKey(_key);
        }
    }
}   