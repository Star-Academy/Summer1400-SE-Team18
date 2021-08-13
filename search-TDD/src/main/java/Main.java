import controller.ProgramController;

public class Main {
    public static void main(String[] args) {
        ProgramController instance = ProgramController.getInstance();
        instance.getMainMenuController().execute();
    }
}
