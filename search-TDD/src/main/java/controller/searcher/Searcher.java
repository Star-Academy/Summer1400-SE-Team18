package controller.searcher;

import java.util.HashSet;

import model.Database;
import controller.DatabaseController;
import controller.ProgramController;

public interface Searcher {
    HashSet<String> search(String command);

    default HashSet<String> getWordDocuments(String word) {
        DatabaseController databaseController = ProgramController.getDatabaseController();
        if  (databaseController.wordExistsInDataBase(word))
            return databaseController.getDataNamesForWord(word).getFileNames();
        else 
            return new HashSet<String>();
    }
}
