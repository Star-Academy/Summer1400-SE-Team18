package controller;

import java.util.Set;

public class SetProcessor {
    
    public void addAll(Set<String> initialSet, Set<String> secondSet) {
        initialSet.addAll(secondSet);
    }

    public void removeAll(Set<String> initialSet, Set<String> secondSet) {
        initialSet.removeAll(secondSet);
    }

    public void retainAll(Set<String> initialSet, Set<String> secondSet) {
        initialSet.retainAll(secondSet);
    }
}
