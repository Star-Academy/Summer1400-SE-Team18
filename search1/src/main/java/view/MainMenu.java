package view;

import java.util.Scanner;

import controller.MainMenuController;

public class MainMenu {
    public static void run() {
        String command;
        final Scanner scanner = new Scanner(System.in);
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
        System.out.println("read : to add a file to database (with path)\n" + 
                "choose : choose a file from file explorer\n" +
                "search : search for a word in the current database\n" + 
                "quit : quit the program");
    }

    private static void search(String command) {
        // todo
    }

    private static void read(String command) {
        try {
            if (MainMenuController.readFile(command.substring(command.indexOf(' ') + 1)))
                System.out.println("file added to database.");
            else System.out.println("wrong file name!");
        } catch(Exception e) {
            System.out.println("wrong file name!");
        }
    }

    private static void chooseFile() {
        //
    }
}
