package model.reader;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.*;

import static controller.WordController.*;

public class FileReader implements Reader {

    @Override
    public void read(String fileString) {
        File file;
        if ((file = getFile(fileString)) == null) return;
        String[] words = getFileWords(file);
        if (words != null) addWordsToData(words, file.getName());
    }

    private File getFile(String fileString) {
        File file = new File(fileString);
        return file.exists() && file.isFile() ? file : null;
    }

    private String[] getFileWords(File file) {
        try {
            String text = new String(Files.readAllBytes(Paths.get(file.getPath())));
            text = removeNonAlphabetical(text);
            String[] result = getCommands(text);
            return Arrays.asList(result).stream().map(s -> getStem(s)).toArray(String[]::new);
        } catch (IOException e) {return  null;}
    }

    private void addWordsToData(String[] words, String fileName) {
        for (String string : words) {
            if (!DATA.containsKey(string)) 
                DATA.put(string, new HashSet<>(Arrays.asList(new String[]{fileName})));
            else 
                DATA.get(string).add(fileName);
        }
    }
    
}
