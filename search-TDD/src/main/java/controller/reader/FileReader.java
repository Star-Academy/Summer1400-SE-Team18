package controller.reader;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

public class FileReader implements Reader {
    
    @Override
    public String read(String fileString) {
        File file = new File(fileString);
        if (fileIsNotValid(file)) return null;
        try {
            return getFileContent(file);
        } catch (Exception e) {return null;}
    }
    
    private boolean fileIsNotValid(File file) {
        return !(file.exists() && file.isFile());
    }

    private String getFileContent(File file) throws Exception{
        Path filePath = Paths.get(file.getPath());
        byte[] fileBytes = Files.readAllBytes(filePath);
        return new String(fileBytes);
    }

}
