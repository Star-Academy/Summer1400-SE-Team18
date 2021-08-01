package controller.searcher;

import java.util.HashSet;

public interface Searcher {
    HashSet<String> search(String command);
}
