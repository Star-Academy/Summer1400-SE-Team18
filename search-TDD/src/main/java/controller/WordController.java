package controller;

import static controller.ProgramController.getInstance;

import java.util.Arrays;
import java.util.stream.Stream;

public class WordController {

    public String[] textSeperator(String text) {
        String cleanText = removeNonAlphabetical(text);
        String[] commands = getCommands(cleanText);
        return mapWordToWordStem(commands);
    }

    private String[] mapWordToWordStem(String[] words) {
        Stream<String> wordsStream = Arrays.stream(words);
        Stream<String> stemmedWordsStream = wordsStream.map(e -> getStem(e));
        return stemmedWordsStream.toArray(String[]::new);
    }

    public String getStem(String word) {
        ProgramController controllerInstance = getInstance();
        return controllerInstance.getPorterStemmer().stem(word);
    }

    public String removeNonAlphabetical(String text) {
        return text.toLowerCase().replaceAll("[^a-z0-9]", " ");
    }

    public String[] getCommands(String string) {
        return string.split("[\\s]+");
    }
}