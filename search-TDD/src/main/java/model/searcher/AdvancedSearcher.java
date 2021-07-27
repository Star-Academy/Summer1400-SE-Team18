package model.searcher;

import java.util.HashSet;
import java.util.ArrayList;
import java.util.Arrays;

public class AdvancedSearcher implements Searcher {

    @Override
    public HashSet<String> search(String command) {
        HashSet<String> result = new HashSet<>();
        getTagWordsDocuments(command.split(" "));
        return null;
    }
    
    private HashSet<String> getTagWordsDocuments(String[] words) {
        for (String word : words) {
            if (word.startsWith("+")) {
                
            }
        }
    }

    private HashSet<String> getPlusWordsDocuments(String[] words) {
        HashSet<String> result = new HashSet<>();
        for (String word : words) {
            result.addAll(getWordDocuments(word));
        }
        return result;
    }
    
    private HashSet<String> getMinusWords(String[] words) {
        return Arrays.stream(words).filter(e -> e.startsWith("-")).toArray(String[]::new);
    }

    private String[] getPlusWords(String[] words) {
        ArrayList<String> plusWords = new ArrayList<>();
        for (String word : words) {
            if (word.startsWith("+")) {
                plusWords.add(word);
            }
        }
        return Arrays.stream(words).filter(e -> e.startsWith("+")).toArray(String[]::new);
    } 

}