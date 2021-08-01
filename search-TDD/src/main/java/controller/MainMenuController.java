package controller;

import static controller.IndexController.*;

import java.util.HashSet;

import controller.searcher.*;
import view.Menu;

public class MainMenuController {

    public void execute() {
        String command;
        Menu.showMessage("Welcome to Searcher!");
        while (!(command = Menu.getNextLine()).equals("quit")) {
            command = command.toLowerCase();
            commandParser(command);
        }
        Menu.showMessage("We hope to see you again soon!");
    }

    private void commandParser(String command) {
        String parsedCommand = cutCommandPartOfString(command);
        if (command.startsWith("read")) {
            readCommand(parsedCommand);
        } else if (command.startsWith("search")) {
            searchCommand(parsedCommand);
        }
    }

    private String cutCommandPartOfString(String command) {
        return command.substring(command.indexOf(' ') + 1);
    }
 
    private void readCommand(String folderName) {
        addFolderToDatabase(folderName);
    }
    
    private void searchCommand(String command) {
        Searcher searcher = getCorrectSearcher(command);
        HashSet<String> searchResult = searcher.search(command);
        String finalResult = getResult(searchResult);
        Menu.showMessage(finalResult);
    }

    private String getResult(HashSet<String> set) {
        return set.size() == 0 ? "No results found!" : set.toString();
    }

    private Searcher getCorrectSearcher(String command) {
        return command.matches("\\+|-") ? ProgramController.getAdvancedSearcher() : ProgramController.getNormalSearcher();
    }
}