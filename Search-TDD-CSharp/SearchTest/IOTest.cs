using static SearchTest.TestEssentials;
using System.Collections.Generic;
using NSubstitute;
using Search.Dependencies;
using Search.IO;
using Xunit;
using Xunit.Priority;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [DefaultPriority(10)]
    public class IoTest
    {
        
        private readonly Manager _managerInstance = Manager.GetInstance();

        private readonly IReader _fileReader = new FileReader();
        private readonly IReader _folderReader = new FolderReader();
        private readonly string _lineSeparator = TestEssentials.LineSeparator;

        public IoTest()
        {
            Reset();
        }
        
        [Fact]
        public void Should_Read_When_Path_Is_File()
        {
            var readingData = _fileReader.Read("TestDataBase/3");
            var expectedString = $"man sag mikham{_lineSeparator}sag khoshgel - mikham !!! mio !!!{_lineSeparator}";
            Assert.Equal(expectedString, readingData["3"]);
        }
        
        [Fact]
        public void Should_Read_When_Path_Is_Directory()
        {
            IReader reader = Substitute.For<IReader>();
            reader.Read("TestDataBase\\1").Returns(new Dictionary<string, string>()
            {
                {
                    "1", $"Hello Dear,{_lineSeparator}" +
                         $"I am Mohammad.{_lineSeparator}"
                }
            });
            reader.Read("TestDataBase\\3").Returns(new Dictionary<string, string>()
            {
                {
                    "3", $"man sag mikham{_lineSeparator}" +
                         $"sag khoshgel -  !!! mio !!!{_lineSeparator}"
                }
            });
            reader.Read("TestDataBase\\4").Returns(new Dictionary<string, string>()
            {
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            });
            _managerInstance.FileReaderInstance = reader;
            var readingData = _folderReader.Read("TestDataBase");
            var expectedData = new Dictionary<string, string>()
            {
                {
                    "1", $"Hello Dear,{_lineSeparator}" +
                         $"I am Mohammad.{_lineSeparator}"
                },
                {
                    "3", $"man sag mikham{_lineSeparator}" +
                         $"sag khoshgel -  !!! mio !!!{_lineSeparator}"
                },
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            };

            Assert.Equal(readingData, expectedData);
        }
    }
}