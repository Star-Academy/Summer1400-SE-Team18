package controller;

import java.util.HashSet;

import model.Data;
import model.Database;

public class DatabaseController {

    public boolean wordExistsInDataBase(String word) {
        return Database.getData().stream().filter(e -> wordEqualsData(word, e)).count() != 0;
    }

    public void addWordToDatabase(String word, HashSet<String> fileNames) {
        Data data = new Data(word, fileNames);
        Database.getData().add(data);
    }

    public Data getDataForWord(String word) {
        for (Data data : Database.getData()) {
            if (wordEqualsData(word, data)) return data;
        }
        return Data.getNullData();
    }

    private boolean wordEqualsData(String word, Data data) {
        return data.getWord().equals(word);
    }
}