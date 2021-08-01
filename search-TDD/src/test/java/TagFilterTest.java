import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.HashSet;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import controller.TagFilter;
import model.TagsInterface;

public class TagFilterTest {

    @Test
    public void tagFilterTest() {
        String command = "+a +b -c d e +f g";
        TagsInterface filteredTags = TagFilter.parse(command);
        //No Tags
        HashSet<String> expectedNoTags = new HashSet<>();
        expectedNoTags.add("e");
        expectedNoTags.add("d");
        expectedNoTags.add("g");
        //Plus Tags
        HashSet<String> expectedPlusTags = new HashSet<>();
        expectedPlusTags.add("a");
        expectedPlusTags.add("b");
        expectedPlusTags.add("f");
        //Minus Tags
        HashSet<String> expectedMinusTags = new HashSet<>();
        expectedMinusTags.add("c");
        Assertions.assertAll(
            () -> assertEquals(expectedNoTags, filteredTags.getNoTags()),
            () -> assertEquals(expectedPlusTags, filteredTags.getPlusTags()),
            () -> assertEquals(expectedMinusTags, filteredTags.getMinusTags())
        );
    
    }
    
}
