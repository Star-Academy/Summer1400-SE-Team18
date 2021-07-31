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

    // private File getFile(String fileString) {
    //     File file = new File(fileString);
    //     return file.exists() && file.isFile() ? file : null;
    // }

    // private String[] getFileWords(File file) {
    //     try {
    //         String text = new String(Files.readAllBytes(Paths.get(file.getPath())));
    //         text = removeNonAlphabetical(text);
    //         String[] result = getCommands(text);
    //         return Arrays.asList(result).stream().map(s -> getStem(s)).toArray(String[]::new);
    //     } catch (IOException e) {return  null;}
    // }

    // private void addWordsToData(String[] words, String fileName) {
    //     for (String word : words) {
    //         if (!isWordAlreadyInDatabase(word)) 
    //             createData(word, new HashSet<>(Arrays.asList(new String[]{fileName})));
    //         else 
    //             DATA.get(word).add(fileName);
    //     }
    // }

    // private boolean isWordAlreadyInDatabase(String word) {
    //     return getDatabaseController().wordExistsInDataBase(word);
    // };
    
    // private void createData(String word, HashSet<String> fileNames) {
    //     getDatabaseController().addWordToDatabase(word, fileNames);
    // }

    // private DatabaseController getDatabaseController() {
    //     return ProgramController.getDatabaseController();
    // }

}
