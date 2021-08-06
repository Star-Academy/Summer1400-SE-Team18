package controller;

import java.util.HashSet;

import controller.searcher.*;
import view.Menu;

public class MainMenuController {

    public void execute() {
        String command;
        Menu.showMessage("Welcome to Searcher!");
        while (!(command = Menu.getNextLine()).equals("quit")) {
            command = command.toLowerCase();
            chooseCommand(command);
        }
        Menu.showMessage("We hope to see you again soon!");
    }

    private void chooseCommand(String command) {
        String parsedCommand = command.substring(command.indexOf(' ') + 1);
        if (command.startsWith("read")) {
            readCommand(parsedCommand);
        } else if (command.startsWith("search")) {
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