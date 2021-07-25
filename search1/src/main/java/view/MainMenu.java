package view;

import java.util.Scanner;

import controller.MainMenuController;
import controller.ProgramController;
import controller.SearchController;

public class MainMenu {

    private static MainMenu instance;

    static {
        instance = new MainMenu();
    }

    private MainMenu() {
    }

    public void run() {
        String command;
        Scanner scanner = ProgramController.getScanner();
        System.out.println("********** Main Menu **********");
        while(true) {
            command = scanner.nextLine();
            if (command.startsWith("read")) {
                read(command);
            } else if (command.startsWith("search")) {
                search();
            } else if (command.startsWith("help")) {
                help();
            } else if (command.startsWith("quit")) {
                quit();
            }
        }
    }

    private void help() {
        System.out.println("read : to add a folder to database (with path)\n" + 
                "choose : choose a file from file explorer\n" +
                "search : search for a word in the current database\n" + 
                "quit : quit the program");
    }

    private void search() {
        SearchController.getInstance().run();
    }

    private void read(String command) {
        try {
            if (MainMenuController.getInstance().readFolder(command.substring(command.indexOf(' ') + 1)))
                System.out.println("folder added to database.");
            else System.out.println("wrong folder name!");
        } catch(Exception e) {
            System.out.println("wrong folder name!");
        }
    }

    private void quit() {
        ProgramController.getScanner().close();
        System.exit(0);
    }

    public static MainMenu getInstance() {
        return instance;
    }
}
