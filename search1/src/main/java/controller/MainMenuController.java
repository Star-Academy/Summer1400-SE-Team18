package controller;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;

import model.CustomStemmer;
import model.Location;

public class MainMenuController {

    private static MainMenuController instance;
    private static CustomStemmer stemmer; 
    private final static HashMap<String, ArrayList<Location>> INDEXE_MAP;

    static {
        instance = new MainMenuController();
        INDEXE_MAP = new HashMap<>();
        stemmer = new CustomStemmer();
    }

    private MainMenuController() {
    }

    public static MainMenuController getInstance() {
        return instance;
    }

    public boolean readFolder(String folderName) {
        File directory = new File(folderName);
        if (!directory.exists() || !directory.isDirectory()) return false;
        for (File file : directory.listFiles())
            readFile(folderName + "\\" + file.getName());
        return true;
    }

    public void readFile(String filename) {
        File file = new File(filename);
        if (!file.exists()) return;
        try {
            String[] words = getFileWords(file);
            setIndexes(file, words);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private void setIndexes(File file, String[] words) {
        for (int i = 0; i < words.length; i++) {
            String word = words[i];
            word = stemmer.stemWord(word);
            if (isPrePosition(word)) continue;
            if (INDEXE_MAP.containsKey(word)) INDEXE_MAP.get(word).add(new Location(file, i));
            else INDEXE_MAP.put(word, new ArrayList<>(Arrays.asList(new Location(file, i))));
        }
    }

    private String[] getFileWords(File file) throws Exception {
        String fileString = new String(Files.readAllBytes(Paths.get(file.getPath())));
        fileString = fileString.replaceAll("[^a-zA-Z0-9\\s]", " ");
        String[] fileStrings = fileString.split("[\\s]+");
        return fileStrings;
    } 

    private boolean isPrePosition(String word) {
        if (word.length() <= 1) return true;
        return word.equals("an") || word.equals("the") || word.equals("as") || word.equals("at");
    }

    public HashMap<String, ArrayList<Location>> getIndexMap() {
        return INDEXE_MAP;
    }
}
