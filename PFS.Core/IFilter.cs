using Newtonsoft.Json.Linq;

namespace PFS.Core
{
    public interface  IFilter
    {
        void Next(IFilter next);
        JObject Apply(JObject json);
    }

    public class IsFinalFilter : IFilter
    {
        public static IFilter Final = new IsFinalFilter();
        public JObject Apply(JObject json)
        {
            return json;
        }

        public void Next(IFilter next)
        {
            throw new NotSupportedException("cant set it");
        }
    }
    public class Filter : IFilter
    {

        private readonly IPipes _pipes;
        private readonly IOperation _operation;
        private IFilter _nextFilter;
        public Filter(IPipes pipes, IOperation operation)
        {
            _pipes = pipes;
            _operation = operation;
            _nextFilter = IsFinalFilter.Final;
        }
         
        public void Next(IFilter next)
        {
            _nextFilter = next;
        }
        public JObject Apply(JObject json)
        {
            if (_pipes.IsConfirmed(json))
                json = _operation.Execute(json);

            return _nextFilter.Apply(json);
        }
    }
}   