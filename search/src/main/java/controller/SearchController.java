package controller;

import java.util.Scanner;
import java.util.*;

import model.AnswersWrapper;
import model.SearchCommandWrapper;
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
            if (command.equals("$back")) {
                MainMenu.getInstance().run();
                break;
            }
            else search(command);
        }
    }

    public void search(String searchFor) {
        SearchCommandWrapper searchCommandWrapper = new SearchCommandWrapper(searchFor);
        AnswersWrapper answersWrapper = new AnswersWrapper(searchCommandWrapper);
        if (searchCommandWrapper.getNoTags().size() != 0) searchWithNoTags(answersWrapper);
        else searchWithoutNoTags(answersWrapper);
        printResult(answersWrapper.getNoTagAnswers());
    }

    private void searchWithNoTags(AnswersWrapper answersWrapper) {
        answersWrapper.getNoTagAnswers().removeAll(answersWrapper.getMinusTagAnswers());
        if (answersWrapper.getPlusTagAnswers().size() != 0) 
            answersWrapper.getNoTagAnswers().retainAll(answersWrapper.getPlusTagAnswers());
    }

    private void searchWithoutNoTags(AnswersWrapper answersWrapper) {
        answersWrapper.getNoTagAnswers().addAll(answersWrapper.getPlusTagAnswers());
        answersWrapper.getNoTagAnswers().removeAll(answersWrapper.getMinusTagAnswers());
    }

    private void printResult(HashSet<String> results) {
        System.out.println(results.size() == 0 ? "No results found!" : results);
    }
}
