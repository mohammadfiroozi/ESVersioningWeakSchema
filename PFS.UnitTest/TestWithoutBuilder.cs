using FluentAssertions.Json;
using Newtonsoft.Json.Linq;
using PFS.Core;

namespace PFS.UnitTest
{
    public class TestWithoutBuilder
    {
        [Fact]
        public void Test1()
        {
            var json = JObject.Parse("{'id' : '1'}");
            var expected = JObject.Parse("{'id' : '1' , 'title':'old state'}");
            var absentKeyPipe = new AbsentKey("title");
            var operation = new DefaultValue("title", "old state");
            var filter = new Filter(absentKeyPipe, operation);
            var actual = filter.Apply(json);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}