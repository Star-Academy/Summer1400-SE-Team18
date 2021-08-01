package controller;

import model.FilteredTags;
import model.TagsInterface;

import java.util.HashSet;

import static controller.ProgramController.*;

public class TagFilter {
    
    public static TagsInterface parse(String tags) {
        FilteredTags filteredTags = new FilteredTags();
        for (String tag : tags.split("\\s+")){
            assignTagToDesiredArrayList(tag, filteredTags);
        }
        return filteredTags;
    }

    private static void assignTagToDesiredArrayList(String tag, FilteredTags filteredTags) {
        String trimmedWord = trimTag(tag);
        if (tag.startsWith(getPlusSign())) addWordToHashSet(trimmedWord, filteredTags.getPlusTags());
        else if (tag.startsWith(getMinusSign())) addWordToHashSet(trimmedWord, filteredTags.getMinusTags());
        else addWordToHashSet(tag, filteredTags.getNoTags());;
    }

    private static void addWordToHashSet(String word, HashSet<String> strings) {
        strings.add(word);
    }

    private static String trimTag(String tag) {
        return tag.substring(1);
    }
}