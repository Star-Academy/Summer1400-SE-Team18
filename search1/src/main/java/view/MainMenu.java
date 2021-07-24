package view;

import java.util.Scanner;

public class MainMenu {
    public static void run() {
        String command;
        final Scanner scanner = new Scanner(System.in);
        while(true) {
            command = scanner.nextLine();
            if (command.startsWith("read")) {
                read();
            } else if (command.startsWith("search")) {
                search();
            } else if (command.startsWith("help")) {
                help();
            } else if (command.startsWith("quit")) {
                scanner.close();
                System.exit(0);
            }
        }
    }

    private static void help() {
        System.out.println("read : to add a file to database (with path)\n" + 
                "search : search for a word in the current database\n" + 
                "quit : quit the program");
    }

    private static void search() {
        // todo
    }

    private static void read() {
        // todo
    }
}
