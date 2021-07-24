package controller;

import java.io.File;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.HashMap;

import model.Location;

public class MainMenuController {
    private final static HashMap<String, ArrayList<Location>> datas = new HashMap<>();

    public static boolean readFile(String filename) {
        File file = new File(filename);
        if (!file.exists()) return false;
        if (!file.getName().endsWith(".txt")) return false;
        try {
            String fileString = new String(Files.readAllBytes(Paths.get(file.getPath())));
            fileString.replaceAll("[^\\w]", "");
            String[] fileStrings = fileString.split("[\\s]+");
            for (int i = 0; i < fileStrings.length; i++) {
                if (datas.containsKey(fileStrings[i])) {
                    datas.get(fileStrings[i]).add(new Location(file.getName(), i));
                } else {
                    ArrayList<Location> arrayList = new ArrayList<>();
                    arrayList.add(new Location(file.getName(), i));
                    datas.put(fileStrings[i], arrayList);
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return true;
    }

    public static void readFromDatas() {

    }
}
