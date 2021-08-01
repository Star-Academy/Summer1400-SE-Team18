package controller.searcher;

import static controller.WordController.getStem;
import controller.ProgramController;
import controller.DatabaseController;

import model.Data;
import java.util.Arrays;

import java.util.HashSet;

public class NormalSearcher implements Searcher {

    @Override
    public HashSet<String> search(String command) {
        String[] wordsToSearch = command.split(" ");
        String[] stemmedWords = getWordsStemmed(wordsToSearch);
        return getAnswerForWords(stemmedWords);
    }

    private String[] getWordsStemmed(String[] words) {
        return Arrays.stream(words).map(e -> getStem(e)).toArray(String[]::new);
    }

    private HashSet<String> getAnswerForWords(String[] words) {
        DatabaseController databaseController = ProgramController.getDatabaseController();
        Data data = databaseController.getDataForWord(words[0]);
        HashSet<String> result = new HashSet<>(data.getFileNames());
        for (String word : words) {
            data = databaseController.getDataForWord(word);
            result.retainAll(data.getFileNames());
        }
        return result;
    }
}