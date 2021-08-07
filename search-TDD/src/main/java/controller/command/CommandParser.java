package controller.command;

import controller.IndexController;
import controller.ProgramController;
import controller.searcher.Searcher;
import view.Menu;

import java.util.HashSet;

public class CommandParser {

    private final static String READ = "read";
    private final static String SEARCH = "search";
    private final static char WHITE_SPACE = ' ';

    public void chooseCommand(String command) {
        String parsedCommand = command.substring(command.indexOf(WHITE_SPACE) + 1);
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
