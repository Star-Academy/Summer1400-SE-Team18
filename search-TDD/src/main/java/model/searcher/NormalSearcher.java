package model.searcher;

import java.util.HashSet;

public class NormalSearcher implements Searcher {

    @Override
    public HashSet<String> search(String command) {
        HashSet<String> result = new HashSet<>();
        if (command.matches("+|-")) return null;
        String[] wordsToSearch = command.split(" ");
        result.addAll(getWordDocuments(wordsToSearch[0]));
        for (String word : wordsToSearch) {
            result.retainAll(getWordDocuments(word));
        }
        return result;
    }
}