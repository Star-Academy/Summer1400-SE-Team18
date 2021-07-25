package controller;

import java.util.Scanner;

import view.MainMenu;

public class ProgramController {
    
    private static ProgramController instance;
    private final static Scanner scanner;

    static {
        instance = new ProgramController();
        scanner = new Scanner(System.in);
    }

    private ProgramController() {
    }

    public static ProgramController getInstance() {
        return instance;
    }

    public static Scanner getScanner() {
        return scanner;
    }

    public void run() {
        MainMenu.getInstance().run();
    }

}
