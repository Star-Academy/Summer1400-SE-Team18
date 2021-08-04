using System;
using System.Collections.Generic;
using NSubstitute;
using Search.Dependencies;
using Search.IO;
using Xunit;

namespace SearchTest
{
    [TestCaseOrderer("SearchTest.PriorityOrderer", "SearchTest")]
    public class IoTest
    {
        private readonly IReader _fileReader = new FileReader();
        private readonly IReader _folderReader = new FolderReader();
        private readonly string _ls = TestEssentials.Ls;

        [Fact, TestPriority(10)]
        public void Should_Read_When_Path_Is_File()
        {
            var readingData = _fileReader.Read("TestDataBase/3");
            var expectedString = $"man sag mikham{_ls}sag khoshgel - mikham !!! mio !!!{_ls}";
            Assert.Equal(expectedString, readingData["3"]);
        }

        [Fact, TestPriority(0)]
        public void Should_Read_When_Path_Is_Directory()
        {
            IReader reader = Substitute.For<IReader>();
            reader.Read("TestDataBase\\1").Returns(new Dictionary<string, string>()
            {
                {
                    "1", $"Hello Dear,{_ls}" +
                         $"I am Mohammad.{_ls}"
                }
            });
            reader.Read("TestDataBase\\3").Returns(new Dictionary<string, string>()
            {
                {
                    "3", $"man sag mikham{_ls}" +
                         $"sag khoshgel -  !!! mio !!!{_ls}"
                }
            });
            reader.Read("TestDataBase\\4").Returns(new Dictionary<string, string>()
            {
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            });
            Manager.FileReaderInstance = reader;
            var readingData = _folderReader.Read("TestDataBase");
            var expectedData = new Dictionary<string, string>()
            {
                {
                    "1", $"Hello Dear,{_ls}" +
                         $"I am Mohammad.{_ls}"
                },
                {
                    "3", $"man sag mikham{_ls}" +
                         $"sag khoshgel -  !!! mio !!!{_ls}"
                },
                {
                    "4", "Mir rafte dubai vase nakhle talaii !!"
                }
            };

            Assert.Equal(readingData, expectedData);
        }
    }
}