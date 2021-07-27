package model.reader;

import java.io.File;

public class FolderReader implements Reader {

    @Override
    public void read(String name) {
        File file;
        if ((file = getFile(name)) == null) return;
        addFileChildren(file);
    }

    private File getFile(String filename) {
        File file = new File(filename);
        return file.isDirectory() && file.exists() ? file : null;
    }

    private void addFileChildren(File file) {
        File[] files = file.listFiles();
        Reader fileReader = new FileReader();
        for (File temporaryFile : files) {
            fileReader.read(temporaryFile.getPath());
        }
    }
}
