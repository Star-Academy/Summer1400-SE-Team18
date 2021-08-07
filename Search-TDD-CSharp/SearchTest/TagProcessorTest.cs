using Search.Dependencies;
using Search.Tags;
using Xunit;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    public class TagProcessorTest
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();
        
        [Fact]
        public void Tag_Processor_Test()
        {
            Tag expectedTag = new Tag("mohammad", TagType.Plus);
            Tag actualTag = _managerInstance.TagProcessor.Process("+mohammad");
            Assert.Equal(expectedTag, actualTag);
        }
    }
}