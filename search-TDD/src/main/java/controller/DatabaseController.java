package controller;

import java.util.HashSet;
import java.util.stream.Stream;

import model.Data;
import model.Database;

public class DatabaseController {

    public boolean wordExistsInDataBase(String word) {
        Stream<Data> datasStream = Database.getData().stream();
        Stream<Data> filteredDatasStream = datasStream.filter(e -> wordEqualsData(word, e));
        return filteredDatasStream.count() != 0;
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