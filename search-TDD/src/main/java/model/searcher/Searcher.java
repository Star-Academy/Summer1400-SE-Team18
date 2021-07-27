package model.searcher;

import java.util.HashSet;
import model.reader.Reader;

public interface Searcher {
    HashSet<String> search(String command);

    default HashSet<String> getWordDocuments(String word) {
        return Reader.DATA.containsKey(word) ? Reader.DATA.get(word) : new HashSet<String>();
    }
}
