package controller;

import static controller.ProgramController.*;

import model.FilteredTags;
import model.TagsInterface;

import java.util.HashSet;

public class TagFilter {
    private static final String PLUS_SIGN = "+";
    private static final String MINUS_SIGN = "-";
    
    public TagsInterface parse(String tags) {
        FilteredTags filteredTags = new FilteredTags();
        for (String tag : tags.split("\\s+")){
            assignTagToDesiredArrayList(tag, filteredTags);
        }
        return filteredTags;
    }

    private void assignTagToDesiredArrayList(String tag, FilteredTags filteredTags) {
        String trimmedWord = trimTag(tag);
        if (tag.startsWith(PLUS_SIGN))
            addWordToHashSet(trimmedWord, filteredTags.getPlusTags());
        else if (tag.startsWith(MINUS_SIGN))
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