package model;

import java.util.HashSet;


public class Data {

    private final String WORD;
    private final HashSet<String> FILENAMES;

    public Data(String WORD, HashSet<String> FILENAMES) {
        this.FILENAMES = FILENAMES;
        this.WORD = WORD;
    }

    public String getWord() {
        return WORD;
    }

    public HashSet<String> getFileNames() {
        return FILENAMES;
    }

    @Override
    public boolean equals(Object object) {
        if (!( object instanceof Data )) return false;
        Data dataObject = (Data) object;
        return WORD.equals(dataObject.WORD) && FILENAMES.equals(dataObject.FILENAMES);
    }

    @Override
    public String toString() {
        return WORD + "\n" + FILENAMES + "\n";
    }

    @Override
    public int hashCode() {
        return (WORD + "~" + FILENAMES.toString()).hashCode();
    }

}