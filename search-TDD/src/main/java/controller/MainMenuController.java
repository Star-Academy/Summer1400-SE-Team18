package controller;

import java.util.HashSet;

import controller.searcher.*;
import view.Menu;

public class MainMenuController {

    private final static String WELCOME_STRING = "Welcome to Searcher!";
    private final static String BYE_STRING = "We hope to see you again soon!";
    private final static String QUIT = "quit";
    private final static String READ = "read";
    private final static String SEARCH = "search";


    public void execute() {
        String command;
        Menu.showMessage(WELCOME_STRING);
        while (!(command = Menu.getNextLine()).equals(QUIT)) {
            command = command.toLowerCase();
            chooseCommand(command);
        }
        Menu.showMessage(BYE_STRING);
    }

    private void chooseCommand(String command) {
        String parsedCommand = command.substring(command.indexOf(' ') + 1);
        if (command.startsWith(READ)) {
            readCommand(parsedCommand);
        } else if (command.startsWith(SEARCH)) {
            searchCommand(parsedCommand);
        }
    }
 
    private void readCommand(String folderName) {
        ProgramController controllerInstance = ProgramController.getInstance();
        IndexController indexController = controllerInstance.getIndexController();
        indexController.addFolderToDatabase(folderName);
    }
    
    private void searchCommand(String command) {
        ProgramController controllerInstance = ProgramController.getInstance();
        Searcher searcher = controllerInstance.getSearcher();
        HashSet<String> searchResult = searcher.search(command);
        Menu.showResult(searchResult);
    }
}