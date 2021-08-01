package model;

import java.util.HashSet;

public interface TagsInterface {
    HashSet<String> getNoTags();
    HashSet<String> getPlusTags();
    HashSet<String> getMinusTags();
}