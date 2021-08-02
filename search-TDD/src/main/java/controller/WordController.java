package controller;

import static controller.ProgramController.getPorterStemmer;

import java.util.Arrays;

public class WordController {

    public String[] textSeperator(String text) {
        String cleanText = removeNonAlphabetical(text);
        String[] commands = getCommands(cleanText);
        return mapWordToWordStem(commands);
    }

    private String[] mapWordToWordStem(String[] words) {
        return Arrays.stream(words).map(e -> getStem(e)).toArray(String[]::new);
    }

    public String getStem(String word) {
        return getPorterStemmer().stem(word);
    }

    public String removeNonAlphabetical(String text) {
        return text.toLowerCase().replaceAll("[^a-z0-9]", " ");
    }

    public String[] getCommands(String string) {
        return string.split("[\\s]+");
    }
}