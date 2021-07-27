package model.reader;

import java.io.File;
import java.util.*;

public interface Reader {
    HashMap<String, Set<String>> DATA = new HashMap<>();
    void read(String name);
}
