package controller;

import java.util.Set;

public class SetProcessor {
    
    public void addAll(Set initialSet, Set secondSet) {
        initialSet.addAll(secondSet);
    }

    public void removeAll(Set initialSet, Set secondSet) {
        initialSet.removeAll(secondSet);
    }

    public void retainAll(Set initialSet, Set secondSet) {
        initialSet.retainAll(secondSet);
    }
}
