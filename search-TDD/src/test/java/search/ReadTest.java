package search;

import static org.junit.jupiter.api.Assertions.*;
import static controller.WordController.*;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import model.reader.*;

public class ReadTest {

    @BeforeEach
    public void beforeEach() {
        Reader.DATA.clear();
    }

    @Test
    public void readFolder() {
        Reader folderReader = new FolderReader();
        folderReader.read("TestDataBase");
        HashMap<String, HashSet<String>> expectedData = new HashMap<>();
        //file 1
        expectedData.put(getStem("hello"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("dear"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("i"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("am"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("mohammad"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        //file 3
        expectedData.put(getStem("man"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        expectedData.put(getStem("sag"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        expectedData.put(getStem("mikham"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        expectedData.put(getStem("khoshgel"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        expectedData.put(getStem("mikham"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        expectedData.put(getStem("mio"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        //file 4
        expectedData.put(getStem("mir"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        expectedData.put(getStem("rafte"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        expectedData.put(getStem("dubai"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        expectedData.put(getStem("vase"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        expectedData.put(getStem("nakhle"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        expectedData.put(getStem("talaii"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        assertTrue(expectedData.equals(Reader.DATA));
    }

    @Test
    public void readFile() {
        Reader fileReader = new FileReader();
        fileReader.read("TestDataBase/1");
        HashMap<String, HashSet<String>> expectedData = new HashMap<>();
        expectedData.put(getStem("hello"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("dear"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("i"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("am"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        expectedData.put(getStem("mohammad"), new HashSet<>(Arrays.asList(new String[]{"1"})));
        assertTrue(expectedData.equals(Reader.DATA));
    }

}