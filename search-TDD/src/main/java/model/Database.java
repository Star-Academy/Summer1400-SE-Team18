package model;

import java.util.HashSet;

public class Database {
    private static HashSet<Data> DATA = new HashSet<>();

    public static HashSet<Data> getData() {
        return DATA;
    }
}