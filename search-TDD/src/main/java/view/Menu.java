package view;

import controller.ProgramController;

public class Menu {

    public static void showMessage(String message) {
        System.out.println(message);
    }

    public static String getNextLine() {
        return ProgramController.getScanner().nextLine();
    }
}
