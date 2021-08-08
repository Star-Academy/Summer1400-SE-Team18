using static SearchTest.TestEssentials;
using System.Collections.Generic;
using NSubstitute;

using Search.IO;
using Search.IO.FileIO;
using Search.IO.FolderIO;
using Xunit;
using Xunit.Priority;

namespace SearchTest
{
    [Collection("Test Collection 1")]
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    [DefaultPriority(10)]
    public class IoTest
    {
        private readonly string _lineSeparator = TestEssentials.LineSeparator;
        private readonly KeyValuePair<string, string>[] _fileContents;
        private IReader _fileReader;
        private IReader _folderReader;

        public IoTest()
        {
            _fileContents = new KeyValuePair<string, string>[3];
            InitializeFileContent();
            InitializeFields();
        }

        private void InitializeFileContent()
        {
            _fileContents[0] = KeyValuePair.Create("1",
                $"Hello Dear,{_lineSeparator}I am Mohammad.{_lineSeparator}");
            _fileContents[1] = KeyValuePair.Create("3",
                $"man sag mikham{_lineSeparator}sag khoshgel - mikham !!! mio !!!{_lineSeparator}");
            _fileContents[2] = KeyValuePair.Create("4",
                "Mir rafte dubai vase nakhle talaii !!");
        }

        private void InitializeFields()
        {
            _fileReader = new FileReader();
        }

        [Fact]
        public void Read_ShouldReadCorrectly_WhenPathIsFile()
        {
            var readingData = _fileReader.Read("TestDataBase/3");
            var expectedString = _fileContents[1].Value;
            Assert.Equal(expectedString, readingData[_fileContents[1].Key]);
        }

        [Fact]
        public void Read_ShouldReadCorrectly_WhenPathIsDirectory()
        {
            IFileReader reader = Substitute.For<IFileReader>();
            _fileContents[0] = KeyValuePair.Create("1",
                $"Hello Dear,{_lineSeparator}I am Mohammad.{_lineSeparator}");
            _fileContents[1] = KeyValuePair.Create("3",
                $"man sag mikham{_lineSeparator}sag khoshgel -  !!! mio !!!{_lineSeparator}");
            _fileContents[2] = KeyValuePair.Create("4",
                "Mir rafte dubai vase nakhle talaii !!");

            reader.Read("TestDataBase\\1").Returns(GetDictionaryForFile1());
            reader.Read("TestDataBase\\3").Returns(GetDictionaryForFile3());
            reader.Read("TestDataBase\\4").Returns(GetDictionaryForFile4());
            _folderReader = new FolderReader(reader);
            var readingData = _folderReader.Read("TestDataBase");
            var expectedData = GetDictionaryForFolder();

            Assert.Equal(readingData, expectedData);
        }

        private Dictionary<string, string> GetDictionaryForFile1()
        {
            return new Dictionary<string, string>()
            {
                {
                    _fileContents[0].Key, _fileContents[0].Value
                }
            };
        }

        private Dictionary<string, string> GetDictionaryForFile3()
        {
            return new Dictionary<string, string>()
            {
                {
                    _fileContents[1].Key, _fileContents[1].Value
                }
            };
        }

        private Dictionary<string, string> GetDictionaryForFile4()
        {
            return new Dictionary<string, string>()
            {
                {
                    _fileContents[2].Key, _fileContents[2].Value
                }
            };
        }

        private Dictionary<string, string> GetDictionaryForFolder()
        {
            return new Dictionary<string, string>()
            {
                {
                    _fileContents[0].Key, _fileContents[0].Value
                },
                {
                    _fileContents[1].Key, _fileContents[1].Value
                },
                {
                    _fileContents[2].Key, _fileContents[2].Value
                }
            };
        }
    }
}