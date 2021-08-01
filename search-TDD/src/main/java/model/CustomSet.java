package model;

import java.util.Collection;
import java.util.HashSet;

public class CustomSet<T> extends HashSet<T> {
    
    @Override
    public boolean add(T t) {
        for (T element : this) {
            if (element.equals(t)) return false;
        }
        super.add(t);
        return true;
    }
}
