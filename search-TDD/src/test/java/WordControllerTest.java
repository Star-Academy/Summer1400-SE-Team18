import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

import controller.WordController;

public class WordControllerTest {

    @Test
    public void getCommandsTest() {
        String command = "Hello +Dear -My";
        String[] commands = new String[] {
            "Hello",
            "+Dear",
            "-My"
        };
        assertArrayEquals(commands, WordController.getCommands(command));
    }

    @Test
    public void removeNonAlphabeticalTest() {
        String text = "Hello, I'm Mohammad. nice to meet you!";
        String expectedAlphabeticalText = "hello  i m mohammad  nice to meet you ";
        assertEquals(expectedAlphabeticalText, WordController.removeNonAlphabetical(text));
    }

    @Test
    public void textSeperatorTest() {
        String text = "Any delicate you how kindness horrible outlived servants. You high bed wish help call draw side.";
        String[] expected = new String[] {
            getStem("any"),
            getStem("delicate"),
            getStem("you"),
            getStem("how"),
            getStem("kindness"),
            getStem("horrible"),
            getStem("outlived"),
            getStem("servants"),
            getStem("you"),
            getStem("high"),
            getStem("bed"),
            getStem("wish"),
            getStem("help"),
            getStem("call"),
            getStem("draw"),
            getStem("side")
        };
        assertArrayEquals(expected, WordController.textSeperator(text));
    }

    public String getStem(String word) {
        return WordController.getStem(word);
    } 
    
}
