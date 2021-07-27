package search;

import static org.junit.jupiter.api.Assertions.*;
import static controller.WordController.*;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

import javax.print.DocFlavor.READER;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import model.reader.*;
import model.searcher.AdvancedSearcher;
import model.searcher.NormalSearcher;
import model.searcher.Searcher;

public class SearchTest {

    @BeforeEach
    public void before() {
        Reader.DATA.clear();
    }

    @Test
    public void searchTest1() {
        Reader reader = new FileReader();
        reader.read("mamal");
        Searcher searcher = new NormalSearcher();
        assertTrue(searcher.search("abbas").equals(new HashSet<String>()));
        reader = new FolderReader();
        reader.read("TestDataBase");
        assertTrue(searcher.search("mir").equals(new HashSet<>(Arrays.asList(new String[]{"4"}))));
        assertTrue(searcher.search("mikham").equals(new HashSet<>(Arrays.asList(new String[]{"3"}))));
        reader.read("TestDataBase2");
        assertTrue(searcher.search("sag").equals(new HashSet<>(Arrays.asList(new String[]{"3", "gorbe"}))));
        assertTrue(searcher.search("dubai").equals(new HashSet<>(Arrays.asList(new String[]{"4", "sag"}))));
    }

    @Test
    public void searchTest2() {
        Searcher searcher = new AdvancedSearcher();
        Reader reader = new FolderReader();
        reader.read("TestDataBase");
        assertTrue(searcher.search("mohammad -am").equals(new HashSet<String>()));
        reader.read("TestDataBase2");
        assertTrue(searcher.search("mohammad -am").equals(new HashSet<>(Arrays.asList("mohammad"))));
        assertTrue(searcher.search("taghi +mamooli -dubai").equals(new HashSet<String>()));
        assertTrue(searcher.search("sag +mikham").equals(new HashSet<>(Arrays.asList(new String[]{"3"}))));
        assertTrue(searcher.search("+sag -mikham").equals(new HashSet<>(Arrays.asList(new String[]{"sag"}))));
        assertTrue(searcher.search("+dubai").equals(new HashSet<>(Arrays.asList(new String[]{"sag", "4"}))));
        assertTrue(searcher.search("+dubai +talaii").equals(new HashSet<>(Arrays.asList(new String[]{"sag", "4"}))));
        assertTrue(searcher.search("mohammad -mikham +mohammad").equals(new HashSet<>(Arrays.asList(new String[]{"1", "mohammad"}))));
        assertTrue(searcher.search(""));
    }
}
