package controller;

import java.util.Scanner;
import java.util.*;

import model.CustomStemmer;
import model.Location;
import view.MainMenu;

public class SearchController {

    private static SearchController instance;

    static {
        instance = new SearchController();
    }
    
    private SearchController() {
    }

    public static SearchController getInstance() {
        return instance;
    }

    public void run() {
        String command;
        Scanner scanner = ProgramController.getScanner();
        System.out.println("Please enter word for search ($back for back to main menu): ");
        while(true) {
            command = scanner.nextLine();
            if (command.equals("$back")) MainMenu.run();
            else search(command);
        }
    }

    public HashSet<String> search(String searchFor) {
        String[] words = searchFor.split("[\\s]+");
        ArrayList<HashSet<String>> noTags = new ArrayList<>();
        ArrayList<HashSet<String>> plusTags = new ArrayList<>();
        ArrayList<HashSet<String>> minusTags = new ArrayList<>();
        boolean isNoTag = false;
        for (String word : words) {
            if (word.startsWith("-")) addToList(word.substring(1), minusTags);
            else if (word.startsWith("+")) addToList(word.substring(1), plusTags);
            else {
                addToList(word, noTags);
                isNoTag = true;
            } 
        }
        System.out.println("noTags: " + noTags.size() + "\n" + "plusTags: " + plusTags.size() + "\n" + "minusTags: " + minusTags.size());
        HashSet<String> answers = noTags.size() == 0 ? new HashSet() : noTags.get(0);
        Iterator<String> iterator = answers.iterator();
        while(iterator.hasNext()) {
            String string = iterator.next();
            for (HashSet<String> noTag : noTags) {
                if (!noTag.contains(string)) {
                    iterator.remove(); 
                    break;
                }
            }
        }
        HashSet<String> pluses = new HashSet();
        for (HashSet<String> plusTag : plusTags) pluses.addAll(plusTag);
        HashSet<String> minuses = new HashSet();
        for (HashSet<String> minusTag : minusTags) minuses.addAll(minusTag);

        if (isNoTag) searchWithNoTags(answers, pluses, minuses);
        else searchWithoutNoTags(answers, pluses, minuses);

        printResult(answers);
        return answers; 
    }

    private void searchWithNoTags(HashSet<String> answers, HashSet<String> pluses, HashSet<String> minuses) {
        answers.removeAll(minuses);
        if (pluses.size() != 0) answers.retainAll(pluses);
    }

    private void searchWithoutNoTags(HashSet<String> answers, HashSet<String> pluses, HashSet<String> minuses) {
        answers.addAll(pluses);
        answers.removeAll(minuses);
    }

    private void addToList(String word, ArrayList<HashSet<String>> tags) {
        CustomStemmer wordStemmer = new CustomStemmer(word);
        HashSet<String> hashSet = new HashSet();
        HashMap<String, ArrayList<Location>> datas = MainMenuController.getDatas();
        tags.add(hashSet);
        if (!datas.containsKey(wordStemmer.toString())) return;
        ArrayList<Location> locations = datas.get(wordStemmer.toString());
        for (Location location : locations) hashSet.add(location.getFileName());
    }

    private void printResult(HashSet<String> results) {
        System.out.println(results);
    }
}
