package controller.searcher;

import static controller.WordController.getStem;
import java.util.HashSet;

public class NormalSearcher implements Searcher {
    private final String TAG_REGEX = "\\+|-";

    @Override
    public HashSet<String> search(String command) {
        HashSet<String> result = new HashSet<>();
        if (command.matches(TAG_REGEX)) return null;
        String[] wordsToSearch = command.split(" ");
        result.addAll(getWordDocuments(wordsToSearch[0]));
        for (String word : wordsToSearch) {
            word = getStem(word);
            result.retainAll(getWordDocuments(word));
        }
        return result;
    }
}