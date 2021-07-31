package model;

import model.CustomSet;

public class Database {
    private static CustomSet<Data> DATA = new CustomSet<>();

    public static CustomSet<Data> getData() {
        return DATA;
    }
}