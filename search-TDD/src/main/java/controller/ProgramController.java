package controller;

import java.util.Scanner;

import controller.reader.FolderReader;
import controller.searcher.*;
import controller.reader.*;
import opennlp.tools.stemmer.PorterStemmer;

public class ProgramController {

    private static final ProgramController programController = new ProgramController();
    private final String PLUS_SIGN = "+";
    private final String MINUS_SIGN = "-";
    private DatabaseController databaseController;
    private Reader fileReader;
    private Reader folderReader;
    private Searcher AdvancedSearcher;
    private Scanner scanner;
    private PorterStemmer porterStemmer;
    private MainMenuController mainMenuController;
    private IndexController indexController;
    private TagFilter tagFilter;
    private WordController wordController;

    {
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

    public DatabaseController getDatabaseController() {
        return databaseController;
    }

    public Reader getFileReader() {
        return fileReader;
    }

    public Reader getFolderReader() {
        return folderReader;
    }

    public Scanner getScanner() {
        return scanner;
    }

    public PorterStemmer getPorterStemmer() {
        return porterStemmer;
    }

    public MainMenuController getMainMenuController() {
        return mainMenuController;
    }

    public Searcher getSearcher() {
        return AdvancedSearcher;
    }

    public String getPlusSign() {
        return PLUS_SIGN;
    }

    public String getMinusSign() {
        return MINUS_SIGN;
    }

    public void setScanner(Scanner scanner) {
        this.scanner = scanner;
    }

    public IndexController getIndexController() {
        return indexController;
    }

    public TagFilter getTagFilter() {
        return tagFilter;
    }

    public WordController getWordController() {
        return wordController;
    }

    public static ProgramController getInstance() {
        return programController;
    }
}
