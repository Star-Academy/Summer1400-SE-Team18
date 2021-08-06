package controller;

import java.util.HashSet;

import controller.command.CommandParser;
import controller.searcher.*;
import view.Menu;

public class MainMenuController {

    private final static String WELCOME_STRING = "Welcome to Searcher!";
    private final static String BYE_STRING = "We hope to see you again soon!";
    private final static String QUIT = "quit";

    private final CommandParser commandParser = ProgramController.getInstance().getCommandParser();


    public void execute() {
        String command;
        Menu.showMessage(WELCOME_STRING);
        while (!(command = Menu.getNextLine()).equals(QUIT)) {
            command = command.toLowerCase();
            commandParser.chooseCommand(command);
        }
        Menu.showMessage(BYE_STRING);
    }

}