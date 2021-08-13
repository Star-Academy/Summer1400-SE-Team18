package model;

import java.util.Collection;
import java.util.HashSet;

public class AnswerTags implements TagsInterface {
    private HashSet<String> noTagWords;
    private HashSet<String> plusTagWords;
    private HashSet<String> minusTagWords;
    

    public AnswerTags() {
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

    @Override
    public void addToNoTags(Collection<String> collection) {
        noTagWords.addAll(collection);
    }
}