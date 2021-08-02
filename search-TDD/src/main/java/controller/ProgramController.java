package controller;

import java.util.Scanner;

import controller.reader.FolderReader;
import controller.searcher.*;
import controller.reader.*;
import opennlp.tools.stemmer.PorterStemmer;

public class ProgramController {

    private static final String PLUS_SIGN = "+";
    private static final String MINUS_SIGN = "-";
    private static DatabaseController databaseController;
    private static Reader fileReader;
    private static Reader folderReader;
    private static Searcher AdvancedSearcher;
    private static Scanner scanner;
    private static PorterStemmer porterStemmer;
    private static MainMenuController mainMenuController;
    private static IndexController indexController;
    private static TagFilter tagFilter;
    private static WordController wordController;

    static {
        databaseController = new DatabaseController();
        fileReader = new FileReader();
        folderReader = new FolderReader();
        scanner = new Scanner(System.in);
        porterStemmer = new PorterStemmer();
        mainMenuController = new MainMenuController();
        AdvancedSearcher = new AdvancedSearcher();
        indexController = new IndexController();
        tagFilter = new TagFilter();
        wordController = new WordController();
    }

    private ProgramController() {
    }

    public static DatabaseController getDatabaseController() {
        return databaseController;
    }

    public static Reader getFileReader() {
        return fileReader;
    }

    public static Reader getFolderReader() {
        return folderReader;
    }

    public static Scanner getScanner() {
        return scanner;
    }

    public static PorterStemmer getPorterStemmer() {
        return porterStemmer;
    }

    public static MainMenuController getMainMenuController() {
        return mainMenuController;
    }

    public static Searcher getSearcher() {
        return AdvancedSearcher;
    }

    public static String getPlusSign() {
        return PLUS_SIGN;
    }

    public static String getMinusSign() {
        return MINUS_SIGN;
    }

    public static void setScanner(Scanner scanner) {
        ProgramController.scanner = scanner;
    }

    public static IndexController getIndexController() {
        return indexController;
    }

    public static TagFilter getTagFilter() {
        return tagFilter;
    }

    public static WordController getWordController() {
        return wordController;
    }
}
