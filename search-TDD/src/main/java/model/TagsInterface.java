package model;

import java.util.Collection;
import java.util.HashSet;

public interface TagsInterface {
    HashSet<String> getNoTags();
    HashSet<String> getPlusTags();
    HashSet<String> getMinusTags();
    void addToNoTags(Collection<String> collection);
}