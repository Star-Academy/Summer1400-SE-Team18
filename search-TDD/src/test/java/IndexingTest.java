import static org.junit.jupiter.api.Assertions.*;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;

import controller.IndexController;
import controller.ProgramController;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import model.Database;
import model.Data;

public class IndexingTest {

    @BeforeEach
    public void beforeEach() {
        Database.getData().clear();
    }

    @Test
    public void IndexingFolder() {
        IndexController indexController = ProgramController.getIndexController();
        indexController.addFolderToDatabase("TestDataBase");
        HashSet<Data> expectedData = new HashSet<>();
        //file 1
        expectedData.add(makeData(getStem("hello"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("dear"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("i"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("am"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("mohammad"), new HashSet<>(List.of("1"))));
        //file 3
        expectedData.add(makeData(getStem("man"), new HashSet<>(List.of("3"))));
        expectedData.add(makeData(getStem("sag"), new HashSet<>(List.of("3"))));
        expectedData.add(makeData(getStem("mikham"), new HashSet<>(List.of("3"))));
        expectedData.add(makeData(getStem("khoshgel"), new HashSet<>(List.of("3"))));
        expectedData.add(makeData(getStem("mikham"), new HashSet<>(List.of("3"))));
        expectedData.add(makeData(getStem("mio"), new HashSet<>(List.of("3"))));
        //file 4
        expectedData.add(makeData(getStem("mir"), new HashSet<>(List.of("4"))));
        expectedData.add(makeData(getStem("rafte"), new HashSet<>(List.of("4"))));
        expectedData.add(makeData(getStem("dubai"), new HashSet<>(List.of("4"))));
        expectedData.add(makeData(getStem("vase"), new HashSet<>(List.of("4"))));
        expectedData.add(makeData(getStem("nakhle"), new HashSet<>(List.of("4"))));
        expectedData.add(makeData(getStem("talaii"), new HashSet<>(List.of("4"))));
        assertEquals(expectedData, Database.getData());
    }

    private Data makeData(String word, HashSet<String> fileNames) {
        return new Data(word, fileNames);
    }

    @Test
    public void IndexingFile() {
        IndexController indexController = ProgramController.getIndexController();
        indexController.addFileTextToDatabase("TestDataBase/1");
        HashSet<Data> expectedData = new HashSet<>();
        expectedData.add(makeData(getStem("hello"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("dear"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("i"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("am"), new HashSet<>(List.of("1"))));
        expectedData.add(makeData(getStem("mohammad"), new HashSet<>(List.of("1"))));
        assertEquals(expectedData, Database.getData());
    }

    public String getStem(String word) {
        return ProgramController.getWordController().getStem(word);
    }

}