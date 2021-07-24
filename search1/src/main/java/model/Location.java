package model;

public class Location {

    private static final String ls;

    static {
        ls = System.lineSeparator();
    }

    private final int index;
    private final String filename;
    private final String path;

    public Location(String path, String filename, int index) {
        this.filename = filename;
        this.path = path;
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