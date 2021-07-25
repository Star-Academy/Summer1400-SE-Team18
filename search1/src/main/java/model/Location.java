package model;

import java.io.File;

public class Location {

    private static final String ls;

    static {
        ls = System.lineSeparator();
    }

    private final int index;
    private final String filename;

    public Location(File file, int index) {
        this.filename = file.getName();
        this.index = index;
    }

    public String getFileName() {
        return this.filename;
    }

    public int getIndex() {
        return index;
    }
    
    @Override
    public String toString() {
        return "String index : " + index + ls +
                "File name : " + filename + ls;
    }
}