package controller;

import static controller.ProgramController.*;
import static controller.WordController.*;

import java.io.File;
import java.util.Arrays;
import java.util.HashSet;

public class IndexController {
    private final static String WORD_SPLITTER = "~";

    public static void addFolderToDatabase(String path) {
        String text = getFolderReader().read(path);
        if (text == null) return;
        String[] fileNamesAndWords = text.split(WORD_SPLITTER);
        for (int i = 1; i < fileNamesAndWords.length; i = i + 2) {
            addFileToDatabase(fileNamesAndWords[i], fileNamesAndWords[i + 1]);
        }
    }

    public static void addFileTextToDatabase(String path) {
        String text = getFileReader().read(path);
        if (text == null) return;
        String fileName = findFileName(path);
        addFileToDatabase(fileName, text);
    }

    private static void addFileToDatabase(String filename, String text) {
        String[] words = textSeperator(text);
        Arrays.stream(words).forEach(e -> addWordToDatabase(filename, e));
    }

    private static void addWordToDatabase(String filename, String word) {
        DatabaseController databaseController = ProgramController.getDatabaseController();
        if (databaseController.wordExistsInDataBase(word))
            databaseController.getDataForWord(word).getFileNames().add(filename);
        else 
            databaseController.addWordToDatabase(word, convertNameToHashSet(filename));;
    }

    private static HashSet<String> convertNameToHashSet(String filename) {
        return new HashSet<>(Arrays.asList(new String[]{filename}));
    }

    private static String findFileName(String path) {
        File file = new File(path);
        return file.getName();
    }
}