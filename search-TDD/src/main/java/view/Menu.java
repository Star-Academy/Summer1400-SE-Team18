package view;

import java.util.Scanner;

public class Menu {
    private static Scanner scanner;
    static {
        scanner = new Scanner(System.in);
    }

    public static void showMessage(String message) {
        System.out.println(message);
    }

    public static String getNextLine() {
        return scanner.nextLine();
    }
}
