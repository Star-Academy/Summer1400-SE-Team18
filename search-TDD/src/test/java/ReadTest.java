import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

import controller.reader.*;

public class ReadTest {
    private final String ls = TestEssentials.getLS();

    @Test
    public void readFileTest() {
        Reader fileReader = new FileReader();
        String readingString = fileReader.read("TestDataBase/3");
        String expectedString = "man sag mikham" + ls + "sag khoshgel - mikham !!! mio !!!" + ls;
        assertEquals(expectedString, readingString);
    }

    @Test
    public void readFolderTest() {
        Reader folderReader = new FolderReader();
        String readingString = folderReader.read("TestDataBase");
        String expectedString = "~1~Hello Dear," + 
        ls + 
        "I am Mohammad." + 
        ls + 
        "~3~man sag mikham" + ls + "sag khoshgel - mikham !!! mio !!!" + 
        ls + "~4~Mir rafte dubai vase nakhle talaii !!";
        assertEquals(expectedString, readingString);
    }

}
