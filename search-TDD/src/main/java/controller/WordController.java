package controller;

import static controller.ProgramController.getPorterStemmer;

import java.util.Arrays;

public class WordController {

    public static String[] textSeperator(String text) {
        String cleanText = removeNonAlphabetical(text);
        String[] commands = getCommands(cleanText);
        return mapWordToWordStem(commands);
    }

    private static String[] mapWordToWordStem(String[] words) {
        return Arrays.stream(words).map(e -> getStem(e)).toArray(String[]::new);
    }

    public static String getStem(String word) {
        return getPorterStemmer().stem(word);
    }

    public static String removeNonAlphabetical(String text) {
        return text.toLowerCase().replaceAll("[^a-z0-9]", " ");
    }

    public static String[] getCommands(String string) {
        return string.split("[\\s]+");
    }
}