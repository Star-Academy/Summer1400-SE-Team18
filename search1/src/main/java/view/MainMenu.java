package view;

import java.util.Scanner;

import controller.MainMenuController;
import controller.ProgramController;
import controller.SearchController;

public class MainMenu {
    public static void run() {
        String command;
        Scanner scanner = ProgramController.getScanner();
        while(true) {
            command = scanner.nextLine();
            if (command.startsWith("read")) {
                read(command);
            } else if (command.startsWith("search")) {
                search(command);
            } else if (command.startsWith("help")) {
                help();
            } else if (command.startsWith("choose")) {
                chooseFile();
            } else if (command.startsWith("quit")) {
                scanner.close();
                System.exit(0);
            }
        }
    }

    private static void help() {
        System.out.println("read : to add a folder to database (with path)\n" + 
                "choose : choose a file from file explorer\n" +
                "search : search for a word in the current database\n" + 
                "quit : quit the program");
    }

    private static void search(String command) {
        SearchController.getInstance().run();
    }

    private static void read(String command) {
        try {
            if (MainMenuController.readFolder(command.substring(command.indexOf(' ') + 1)))
                System.out.println("file added to database.");
            else System.out.println("wrong file name!");
        } catch(Exception e) {
            System.out.println("wrong file name!");
        }
    }

    private static void chooseFile() {
        // todo
    }
}
