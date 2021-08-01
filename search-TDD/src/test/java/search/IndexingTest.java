package search;

import static org.junit.jupiter.api.Assertions.*;
import static controller.WordController.*;
import static controller.IndexController.*; 

import java.util.Arrays;
import java.util.HashSet;

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
        addFolderToDatabase("TestDataBase");
        HashSet<Data> expectedData = new HashSet<>();
        //file 1
        expectedData.add(makeData(getStem("hello"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("dear"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("i"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("am"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("mohammad"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        //file 3
        expectedData.add(makeData(getStem("man"), new HashSet<>(Arrays.asList(new String[]{"3"}))));
        expectedData.add(makeData(getStem("sag"), new HashSet<>(Arrays.asList(new String[]{"3"}))));
        expectedData.add(makeData(getStem("mikham"), new HashSet<>(Arrays.asList(new String[]{"3"}))));
        expectedData.add(makeData(getStem("khoshgel"), new HashSet<>(Arrays.asList(new String[]{"3"}))));
        expectedData.add(makeData(getStem("mikham"), new HashSet<>(Arrays.asList(new String[]{"3"}))));
        expectedData.add(makeData(getStem("mio"), new HashSet<>(Arrays.asList(new String[]{"3"}))));
        //file 4
        expectedData.add(makeData(getStem("mir"), new HashSet<>(Arrays.asList(new String[]{"4"}))));
        expectedData.add(makeData(getStem("rafte"), new HashSet<>(Arrays.asList(new String[]{"4"}))));
        expectedData.add(makeData(getStem("dubai"), new HashSet<>(Arrays.asList(new String[]{"4"}))));
        expectedData.add(makeData(getStem("vase"), new HashSet<>(Arrays.asList(new String[]{"4"}))));
        expectedData.add(makeData(getStem("nakhle"), new HashSet<>(Arrays.asList(new String[]{"4"}))));
        expectedData.add(makeData(getStem("talaii"), new HashSet<>(Arrays.asList(new String[]{"4"}))));
        assertTrue(expectedData.equals(Database.getData()));

    }

    private Data makeData(String word, HashSet<String> fileNames) {
        return new Data(word, fileNames);
    }

    @Test
    public void IndexingFile() {
        addFileTextToDatabase("TestDataBase/1");
        HashSet<Data> expectedData = new HashSet<>();
        expectedData.add(makeData(getStem("hello"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("dear"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("i"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("am"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        expectedData.add(makeData(getStem("mohammad"), new HashSet<>(Arrays.asList(new String[]{"1"}))));
        assertTrue(expectedData.equals(Database.getData()));
    }

}