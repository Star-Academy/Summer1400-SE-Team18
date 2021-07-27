package search;

import static org.junit.jupiter.api.Assertions.*;
import static controller.WordController.*;

import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import model.reader.*;
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
        assertEquals(searcher.search("abbas"), new HashSet<String>());
        reader = new FolderReader();
    }
    
}
