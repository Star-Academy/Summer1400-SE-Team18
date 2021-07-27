package controller;

import model.reader.FolderReader;
import model.reader.Reader;
import model.searcher.AdvancedSearcher;
import model.searcher.NormalSearcher;
import model.searcher.Searcher;
import view.Menu;

public class ProgramController {

    private static ProgramController instance;

    static {
        instance = new ProgramController();
    }

    public static ProgramController getInstance() {
        return instance;
    }

    private ProgramController() {
    }

    public void run() {
        String command;
        while (!(command = Menu.getNextLine()).equals("quit")) {
            if (command.startsWith("read")) {
                read(command.substring(command.indexOf(' ') + 1));
            } else if (command.startsWith("search")) {
                search(command.substring(command.indexOf(' ') + 1));
            }
        }
    }

    private void read(String folderName) {
        Reader reader = new FolderReader();
        reader.read(folderName);
    }
    
    private void search(String command) {
        Searcher searcher;
        if (command.contains("+") || command.contains("-"))
            searcher = new AdvancedSearcher();
        else 
            searcher = new NormalSearcher();
        Menu.showMessage(searcher.search(command).toString());
    }
}