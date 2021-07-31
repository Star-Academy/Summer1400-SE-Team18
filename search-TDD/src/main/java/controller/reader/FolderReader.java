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
        Reader reader = ProgramController.getFileReader();
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

    // private File getFile(String filename) {
    //     File file = new File(filename);
    //     return file.isDirectory() && file.exists() ? file : null;
    // }

    // private void addFileChildren(File file) {
    //     File[] files = file.listFiles();
    //     Reader fileReader = new FileReader();
    //     for (File temporaryFile : files) {
    //         fileReader.read(temporaryFile.getPath());
    //     }
    // }
}
