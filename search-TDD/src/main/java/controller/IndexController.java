package controller;

import static controller.ProgramController.*;

import java.io.File;
import java.util.Arrays;
import java.util.HashSet;
import java.util.stream.Stream;

public class IndexController {
    private final String WORD_SPLITTER = "~";

    public void addFolderToDatabase(String path) {
        String text = getFolderReader().read(path);
        if (text == null) return;
        String[] fileNamesAndWords = text.split(WORD_SPLITTER);
        for (int i = 1; i < fileNamesAndWords.length; i = i + 2) {
            addFileToDatabase(fileNamesAndWords[i], fileNamesAndWords[i + 1]);
        }
    }

    public void addFileTextToDatabase(String path) {
        String text = getFileReader().read(path);
        if (text == null) return;
        String fileName = findFileName(path);
        addFileToDatabase(fileName, text);
    }

    private void addFileToDatabase(String filename, String text) {
        WordController wordController = ProgramController.getWordController();
        String[] words = wordController.textSeperator(text);
        Stream<String> wordsStream = Arrays.stream(words);
        wordsStream.forEach(e -> addWordToDatabase(filename, e));
    }

    private void addWordToDatabase(String filename, String word) {
        DatabaseController databaseController = ProgramController.getDatabaseController();
        if (databaseController.wordExistsInDataBase(word))
            databaseController.getDataForWord(word).getFileNames().add(filename);
        else 
            databaseController.addWordToDatabase(word, convertNameToHashSet(filename));;
    }

    private HashSet<String> convertNameToHashSet(String filename) {
        return new HashSet<>(Arrays.asList(new String[]{filename}));
    }

    private String findFileName(String path) {
        File file = new File(path);
        return file.getName();
    }
}