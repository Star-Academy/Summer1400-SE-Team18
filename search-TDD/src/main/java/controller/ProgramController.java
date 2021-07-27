package controller;

import view.Menu;

public class ProgramController {

    private static ProgramController instance;

    static {
        instance = new ProgramController();
    }

    private ProgramController() {
    }

    public static void run() {
        String command;
        while (!(command = Menu.getNextLine()).equals("quit")) {
            if (command.startsWith("read")) {

            } else if (command.startsWith("search")) {

            }
        }
    }
}