package controller.reader;

import java.io.File;

import controller.ProgramController;

public class FolderReader implements Reader {
private final static String WORD_SPLITTER = "~";

    @Override
    public String read(String name) {
        File file = new File(name);
        if ((folderIsNotValid(file))) return null;
        return getSubFilesStrings(file);
    }
    
    private String getSubFilesStrings(File file) {
        StringBuilder stringBuilder = new StringBuilder();
        ProgramController controllerInstance = ProgramController.getInstance();
        Reader reader = controllerInstance.getFileReader();
        for (File temporaryFile : file.listFiles()) {
            stringBuilder.append(WORD_SPLITTER);
            stringBuilder.append(temporaryFile.getName());
            stringBuilder.append(WORD_SPLITTER);
            stringBuilder.append(reader.read(temporaryFile.getPath()));
        }
        return stringBuilder.toString();
    }
    
    private boolean folderIsNotValid(File file) {
        return !(file.exists() && file.isDirectory());
    }

}
