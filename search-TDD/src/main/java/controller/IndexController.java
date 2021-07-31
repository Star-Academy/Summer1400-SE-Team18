package controller;

import static controller.ProgramController.*;
import static controller.WordController.*;

import java.util.Arrays;
import java.util.HashSet;

public class IndexController {
    private final static String WORD_SPLITTER = "~";

    public static void execute(String folderName) {
        String text = getFolderReader().read(folderName);
        String[] fileNamesAndWords = text.split(WORD_SPLITTER);
        for (int i = 1; i < fileNamesAndWords.length; i = i + 2) {
            addFileToDatabase(fileNamesAndWords[i], fileNamesAndWords[i + 1]);
        }
    }

    private static void addFileToDatabase(String filename, String text) {
        String[] words = textSeperator(text);
        Arrays.stream(words).forEach(e -> addWordToDatabase(filename, e));
    }

    private static void addWordToDatabase(String filename, String word) {
        DatabaseController databaseController = ProgramController.getDatabaseController();
        if (databaseController.wordExistsInDataBase(word))
            databaseController.getDataNamesForWord(word).getFileNames().add(filename);
        else 
            databaseController.addWordToDatabase(word, convertNameToHashSet(filename));;
    }

    private static HashSet<String> convertNameToHashSet(String filename) {
        return new HashSet<>(Arrays.asList(new String[]{filename}));
    }
}