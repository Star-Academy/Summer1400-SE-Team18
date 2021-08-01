package search;

import static org.junit.jupiter.api.Assertions.*;
import static controller.WordController.*;
import static controller.IndexController.*;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

import javax.print.DocFlavor.READER;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import controller.ProgramController;
import controller.reader.*;
import controller.searcher.AdvancedSearcher;
import controller.searcher.NormalSearcher;
import controller.searcher.Searcher;
import model.Database;

public class SearchTest {

    @BeforeEach
    public void before() {
        Database.getData().clear();
    }

    @Test
    public void searchTest1() {
        addFolderToDatabase("mamal");
        Searcher searcher = ProgramController.getNormalSearcher();
        assertTrue(searcher.search("abbas").equals(new HashSet<String>()));
        addFolderToDatabase("TestDataBase");
        assertEquals(searcher.search("mir"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        assertEquals(searcher.search("mikham"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        addFolderToDatabase("TestDataBase2");
        assertEquals(searcher.search("sag"), new HashSet<>(Arrays.asList(new String[]{"3", "gorbe"})));
        assertEquals(searcher.search("dubai"), new HashSet<>(Arrays.asList(new String[]{"4", "sag"})));
    }

    @Test
    public void searchTest2() {
        Searcher searcher = new AdvancedSearcher();
        addFolderToDatabase("TestDataBase");
        assertTrue(searcher.search("mohammad -am").equals(new HashSet<String>()));
        addFolderToDatabase("TestDataBase2");
        assertTrue(assertEqual(searcher.search("mohammad -am"), (new HashSet<>(Arrays.asList("mohammad")))));
        assertTrue(searcher.search("-amirraftKhonnashoonKhabeshMioomad").equals(new HashSet<>(Arrays.asList(new String[]{}))));
        assertTrue(searcher.search("taghi +mamooli -dubai").equals(new HashSet<String>()));
        assertTrue(assertEqual(searcher.search("sag +mikham"), (new HashSet<>(Arrays.asList(new String[]{"3", "gorbe"})))));
        assertTrue(assertEqual(searcher.search("+sag -mikham"), (new HashSet<>(Arrays.asList(new String[]{"gorbe"})))));
        assertTrue(searcher.search("+dubai").equals(new HashSet<>(Arrays.asList(new String[]{"sag", "4"}))));
        assertTrue(searcher.search("+dubai +talaii").equals(new HashSet<>(Arrays.asList(new String[]{"sag", "4"}))));
        assertTrue(searcher.search("mohammad -mikham +mohammad").equals(new HashSet<>(Arrays.asList(new String[]{"1", "mohammad"}))));
        assertTrue(searcher.search("abbas +rafte +dubai +sag -mikham -taghi").equals(new HashSet<>(Arrays.asList(new String[]{"4", "gorbe", "mohammad"}))));
    }

    private boolean assertEqual(HashSet<String> given, HashSet<String> expected){
        return expected.equals(given);
    }
}
