import static org.junit.jupiter.api.Assertions.*;
import static controller.IndexController.*;

import java.util.Arrays;
import java.util.HashSet;
import java.util.List;


import controller.IndexController;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import controller.ProgramController;
import controller.searcher.AdvancedSearcher;
import controller.searcher.Searcher;
import model.Database;

public class SearchTest {
    private ProgramController controllerInstance = ProgramController.getInstance();
    private IndexController indexController = controllerInstance.getIndexController();

    @BeforeEach
    public void before() {
        Database.getData().clear();
    }

    @Test
    public void normalSearchTest() {
        indexController.addFolderToDatabase("mamal");
        Searcher searcher = controllerInstance.getSearcher();
        assertTrue(searcher.search("abbas").equals(new HashSet<String>()));
        indexController.addFolderToDatabase("TestDataBase");
        assertEquals(searcher.search("mir"), new HashSet<>(Arrays.asList(new String[]{"4"})));
        assertEquals(searcher.search("mikham"), new HashSet<>(Arrays.asList(new String[]{"3"})));
        indexController.addFolderToDatabase("TestDataBase2");
        assertEquals(searcher.search("sag"), new HashSet<>(Arrays.asList(new String[]{"3", "gorbe"})));
        assertEquals(searcher.search("dubai"), new HashSet<>(Arrays.asList(new String[]{"4", "sag"})));
    }

    @Test
    public void advancedSearchTest() {
        Searcher searcher = new AdvancedSearcher();
        indexController.addFolderToDatabase("TestDataBase");
        assertTrue(searcher.search("mohammad -am").equals(new HashSet<String>()));
    }

    @Test
    public void advancedSearchTest2() {
        Searcher searcher = new AdvancedSearcher();
        indexController.addFolderToDatabase("TestDataBase");
        indexController.addFolderToDatabase("TestDataBase2");
        Assertions.assertAll(
            () -> assertTrue(assertEqual(searcher.search("mohammad -am"), (new HashSet<>(List.of("mohammad"))))),
            () -> assertEquals(searcher.search("-amirraftKhonnashoonKhabeshMioomad"), new HashSet<>(Arrays.asList(new String[]{}))),
            () -> assertEquals(searcher.search("taghi +mamooli -dubai"), new HashSet<String>()),
            () -> assertTrue(assertEqual(searcher.search("sag +mikham"), (new HashSet<>(Arrays.asList(new String[]{"3", "gorbe"}))))),
            () -> assertTrue(assertEqual(searcher.search("+sag -mikham"), (new HashSet<>(Arrays.asList(new String[]{"gorbe"}))))),
            () -> assertEquals(searcher.search("+dubai"), new HashSet<>(Arrays.asList(new String[]{"sag", "4"}))),
            () -> assertEquals(searcher.search("+dubai +talaii"), new HashSet<>(Arrays.asList(new String[]{"sag", "4"}))),
            () -> assertEquals(searcher.search("mohammad -mikham +mohammad"), new HashSet<>(Arrays.asList(new String[]{"1", "mohammad"}))),
            () -> assertEquals(searcher.search("abbas +rafte +dubai +sag -mikham -taghi"), new HashSet<>(Arrays.asList(new String[]{"4", "gorbe", "mohammad"})))
        );   
    }
    private boolean assertEqual(HashSet<String> given, HashSet<String> expected){
        return expected.equals(given);
    }
}
