package view;

import java.util.HashSet;

import controller.ProgramController;

public class Menu {

    public static void showMessage(String message) {
        System.out.println(message);
    }

    public static void showResult(HashSet<String> set) {
        if (set.size() == 0) {
            showMessage("No results found!");
        } else {
            showMessage(set.toString());
        }
    }

    public static String getNextLine() {
        ProgramController controllerInstance = ProgramController.getInstance();
        return controllerInstance.getScanner().nextLine();
    }
}
