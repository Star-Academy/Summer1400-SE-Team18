package model;

import java.util.ArrayList;

public class FilteredTags {
    private ArrayList<String> noTagWords;
    private ArrayList<String> plusTagWords;
    private ArrayList<String> minusTagWords;
    

    public FilteredTags() {
        noTagWords = new ArrayList<>();
        plusTagWords = new ArrayList<>();
        minusTagWords = new ArrayList<>();
    }

    public ArrayList<String> getNoTagWords() {
        return noTagWords;
    }
    
    public ArrayList<String> getPlusTagWords() {
        return plusTagWords;
    }

    public ArrayList<String> getMinusTagWords() {
        return minusTagWords;
    }
}
