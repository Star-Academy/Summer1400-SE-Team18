package controller;

import controller.reader.*;
import controller.searcher.*;
import view.Menu;

public class MainMenuController {

    public void execute() {
        String command;
        while (!(command = Menu.getNextLine()).equals("quit")) {
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
        Reader reader = new FolderReader();
        reader.read(folderName);
    }
    
    private void searchCommand(String command) {
        Searcher searcher = getCorrectSearcher(command);  
         Menu.showMessage(searcher.search(command).toString());
    }

    private Searcher getCorrectSearcher(String command) {
        return command.matches("\\+|-") ? ProgramController.getAdvancedSearcher() : ProgramController.getNormalSearcher();
    }
}