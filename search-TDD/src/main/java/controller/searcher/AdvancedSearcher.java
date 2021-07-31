package controller.searcher;

import controller.ProgramController;
import controller.WordController;

import java.util.Arrays;
import java.util.HashSet;

public class AdvancedSearcher implements Searcher {
    public final static String PLUS_SIGN = ProgramController.getPlusSign();
    public final static String MINUS_SIGN = ProgramController.getMinusSign();
    

    @Override
    public HashSet<String> search(String command) {
        return getWordsDocuments(command.split(" "));
    }
    
    private HashSet<String> getWordsDocuments(String[] words) {
        HashSet<String> noTagWordsDocuments = getNoTagWordsDocuments(getNoTagWords(words));
        HashSet<String> getPlusWordsDocuments = getTagWordsDocumets(getPlusWords(words));
        HashSet<String> getMinusWordsDocuments = getTagWordsDocumets(getMinusWords(words));
        HashSet<String> results = new HashSet<>(noTagWordsDocuments);
        results.addAll(getPlusWordsDocuments);
        results.removeAll(getMinusWordsDocuments);
        return results;
    }

    private HashSet<String> getTagWordsDocumets(String[] words) {
        HashSet<String> result = new HashSet<>();
        for (String word : words) {
            String stemWord = WordController.getStem(word.substring(1));
            HashSet<String> wordDocuments = getWordDocuments(stemWord); 
            result.addAll(wordDocuments);
        }
        return result;
    }

    private HashSet<String> getNoTagWordsDocuments(String[] words) {
        if (words.length == 0) return new HashSet<String>();
        HashSet<String> result = new HashSet<>(getWordDocuments(words[0]));
        for (String word : words) {
            String stemWord = WordController.getStem(word);
            HashSet<String> wordDocuments = getWordDocuments(stemWord); 
            result.retainAll(wordDocuments);
        }
        return result;
    }
    
    private String[] getMinusWords(String[] words) {
        return Arrays.stream(words).filter(e -> e.startsWith(MINUS_SIGN)).toArray(String[]::new);
    }

    private String[] getPlusWords(String[] words) {
        return Arrays.stream(words).filter(e -> e.startsWith(PLUS_SIGN)).toArray(String[]::new);
    } 

    private String[] getNoTagWords(String[] words) {
        return Arrays.stream(words).filter(e -> {
            return doesHaveAnyTags(e);
        }).toArray(String[]::new);
    }

    private boolean doesHaveAnyTags(String word) {
        return word.startsWith(PLUS_SIGN) || word.startsWith(MINUS_SIGN);
    }
}