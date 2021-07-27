package model.searcher;

import java.util.HashSet;
import java.util.List;

import controller.WordController;

import java.util.ArrayList;
import java.util.Arrays;

public class AdvancedSearcher implements Searcher {

    @Override
    public HashSet<String> search(String command) {
        return getWordsDocuments((command.split(" ")));
    }
    
    private HashSet<String> getWordsDocuments(String[] words) {
        HashSet<String> results = new HashSet<>(getNoTagWordsDocuments(getNoTagWords(words)));
        results.addAll(getTagWordsDocumets(getPlusWords(words)));
        results.removeAll(getTagWordsDocumets(getMinusWords(words)));
        return results;
    }

    private HashSet<String> getTagWordsDocumets(String[] words) {
        HashSet<String> result = new HashSet<>();
        for (String word : words) {
            result.addAll(getWordDocuments(WordController.getStem(word.substring(1))));
        }
        return result;
    }

    private HashSet<String> getNoTagWordsDocuments(String[] words) {
        if (words.length == 0) return new HashSet<String>();
        HashSet<String> result = new HashSet<>(getWordDocuments(words[0]));
        for (String word : words) {
            result.retainAll(getWordDocuments(WordController.getStem(word)));
        }
        return result;
    }
    
    private String[] getMinusWords(String[] words) {
        return Arrays.stream(words).filter(e -> e.startsWith("-")).toArray(String[]::new);
    }

    private String[] getPlusWords(String[] words) {
        return Arrays.stream(words).filter(e -> e.startsWith("+")).toArray(String[]::new);
    } 

    private String[] getNoTagWords(String[] words) {
        return Arrays.stream(words).filter(e -> {
            return !e.startsWith("+") && !e.startsWith("-");
        }).toArray(String[]::new);
    }

    private boolean doesNoTagExists(String[] words) {
        return !(Arrays.stream(words).filter(e -> {
            return !e.startsWith("+") && !e.startsWith("-");
        }).findAny().orElse(null) == null);
    }
}