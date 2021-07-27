package controller;

import opennlp.tools.stemmer.PorterStemmer;

public class WordController {
    private final static PorterStemmer PORTER_STEMMER;
    static {
        PORTER_STEMMER = new PorterStemmer();
    }

    public static String getStem(String word) {
        return PORTER_STEMMER.stem(word);
    }

    public static String removeNonAlphabetical(String text) {
        return text.toLowerCase().replaceAll("[^a-z0-9]", " ");
    }

    public static String[] getCommands(String string) {
        return string.split("[\\s]+");
    }
}