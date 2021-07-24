package model;

public class Location {
    private final int index;
    private final String filename;

    public Location(String filename, int index) {
        this.filename = filename;
        this.index = index;
    }

    public String getFileName() {
        return this.filename;
    }

    public int getIndex() {
        return index;
    }
}