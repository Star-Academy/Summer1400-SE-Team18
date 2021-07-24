package controller;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;

import model.CustomStemmer;
import model.Location;

public class MainMenuController {
    private final static HashMap<String, ArrayList<Location>> datas = new HashMap<>();

    public static boolean readFolder(String folderName) {
        File file = new File(folderName);
        if (!file.exists() || !file.isDirectory()) return false;
        for (File file1 : file.listFiles())
            readFile(folderName + "\\" + file1.getName());
        return true;
    }

    public static void readFile(String filename) {
        CustomStemmer stemmer = new CustomStemmer();
        File file = new File(filename);
        if (!file.exists()) return;
        // if (!file.getName().endsWith(".txt")) return false;
        try {
            String fileString = new String(Files.readAllBytes(Paths.get(file.getPath())));
            fileString = fileString.replaceAll("[^a-zA-Z0-9\\s]", " ");
            String[] fileStrings = fileString.split("[\\s]+");
            for (int i = 0; i < fileStrings.length; i++) {
                String word = fileStrings[i];
                stemmer.setWord(word);
                word = fileStrings[i] = stemmer.toString();
                if (isPrePosition(word)) continue;
                if (datas.containsKey(word)) {
                    datas.get(word).add(new Location(file.getPath(), file.getName(), i));
                } else {
                    ArrayList<Location> arrayList = new ArrayList<>();
                    arrayList.add(new Location(file.getPath(), file.getName(), i));
                    datas.put(word, arrayList);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    private static boolean isPrePosition(String word) {
        if (word.length() <= 1) return true;
        return word.equals("an") || word.equals("the") || word.equals("as") || word.equals("at");
    }

    public static HashMap<String, ArrayList<Location>> getDatas() {
        return datas;
    }
}
