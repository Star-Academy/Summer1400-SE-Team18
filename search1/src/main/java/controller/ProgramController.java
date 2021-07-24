package controller;

import view.MainMenu;

public class ProgramController {
    
    private static ProgramController instance;

    static {
        instance = new ProgramController();
    }

    private ProgramController() {
    }

    public static ProgramController getInstance() {
        return instance;
    }

    public void run() {
        MainMenu.run();
    }

}
