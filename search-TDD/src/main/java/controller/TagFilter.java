package controller;

import model.FilteredTags;

import java.util.ArrayList;

import static controller.ProgramController.*;

public class TagFilter {
    
    public static FilteredTags execute(String tags) {
        FilteredTags filteredTags = new FilteredTags();
        for (String tag : tags.split("\\s+")){
            assignTagToDesiredArrayList(tag, filteredTags);
        }
        return filteredTags;
    }

    private static void assignTagToDesiredArrayList(String tag, FilteredTags filteredTags) {
        String trimmedWord = trimTag(tag);
        if (tag.startsWith(getPlusSign())) addWordToArrayList(trimmedWord, filteredTags.getPlusTagWords());
        else if (tag.startsWith(getMinusSign())) addWordToArrayList(trimmedWord, filteredTags.getMinusTagWords());
        else addWordToArrayList(tag, filteredTags.getNoTagWords());;
    }

    private static void addWordToArrayList(String word, ArrayList<String> strings) {
        strings.add(word);
    }

    private static String trimTag(String tag) {
        return tag.substring(1);
    }
}