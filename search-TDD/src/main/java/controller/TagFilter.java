package controller;

import static controller.ProgramController.*;

import model.FilteredTags;
import model.TagsInterface;

import java.util.HashSet;

public class TagFilter {
    
    public TagsInterface parse(String tags) {
        FilteredTags filteredTags = new FilteredTags();
        for (String tag : tags.split("\\s+")){
            assignTagToDesiredArrayList(tag, filteredTags);
        }
        return filteredTags;
    }

    private void assignTagToDesiredArrayList(String tag, FilteredTags filteredTags) {
        ProgramController controllerInstance = ProgramController.getInstance();
        String trimmedWord = trimTag(tag), plusSign = controllerInstance.getPlusSign(), minusSign = controllerInstance.getMinusSign();
        if (tag.startsWith(plusSign)) 
            addWordToHashSet(trimmedWord, filteredTags.getPlusTags());
        else if (tag.startsWith(minusSign)) 
            addWordToHashSet(trimmedWord, filteredTags.getMinusTags());
        else addWordToHashSet(tag, filteredTags.getNoTags());;
    }

    private void addWordToHashSet(String word, HashSet<String> strings) {
        strings.add(word);
    }

    private String trimTag(String tag) {
        return tag.substring(1);
    }
}