package model;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;

import controller.MainMenuController;


public class SearchCommandWrapper {
    private ArrayList<HashSet<String>> noTags = new ArrayList<>();
    private ArrayList<HashSet<String>> plusTags = new ArrayList<>();
    private ArrayList<HashSet<String>> minusTags = new ArrayList<>();

    public SearchCommandWrapper(String command) {
        commandParser(command);
    }

    private void commandParser(String command) {
        String[] words = command.split("[\\s]+");
        for (String word : words) {
            if (word.startsWith("-")) addToList(word.substring(1), minusTags);
            else if (word.startsWith("+")) addToList(word.substring(1), plusTags);
            else addToList(word, noTags);
        }
    }

    private void addToList(String word, ArrayList<HashSet<String>> tags) {
        CustomStemmer wordStemmer = new CustomStemmer(word);
        HashSet<String> hashSet = new HashSet<String>();
        HashMap<String, ArrayList<Location>> datas = MainMenuController.getInstance().getIndexMap();
        tags.add(hashSet);
        if (!datas.containsKey(wordStemmer.toString())) return;
        ArrayList<Location> locations = datas.get(wordStemmer.toString());
        for (Location location : locations) hashSet.add(location.getFileName());
    }

    public ArrayList<HashSet<String>> getNoTags() {
        return noTags;
    }

    public ArrayList<HashSet<String>> getPlusTags() {
        return plusTags;
    }

    public ArrayList<HashSet<String>> getMinusTags() {
        return minusTags;
    }
}