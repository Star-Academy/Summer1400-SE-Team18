package model;

import java.util.HashSet;

public class FilteredTags implements TagsInterface {
    private HashSet<String> noTagWords;
    private HashSet<String> plusTagWords;
    private HashSet<String> minusTagWords;
    

    public FilteredTags() {
        noTagWords = new HashSet<>();
        plusTagWords = new HashSet<>();
        minusTagWords = new HashSet<>();
    }

    @Override
    public HashSet<String> getNoTags() {
        return noTagWords;
    }
    
    @Override
    public HashSet<String> getPlusTags() {
        return plusTagWords;
    }

    @Override
    public HashSet<String> getMinusTags() {
        return minusTagWords;
    }
}
