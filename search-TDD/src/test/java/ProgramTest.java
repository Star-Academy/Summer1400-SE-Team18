import static org.mockito.Mockito.when;

import model.Database;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import controller.ProgramController;

import java.util.Scanner;

@ExtendWith(MockitoExtension.class) 
public class ProgramTest {
    private ProgramController controllerInstance = ProgramController.getInstance();

    @Mock
    Scanner scanner;

    @BeforeEach
    public void init() {
        Database.getData().clear();
    }

    @Test
    public void readCommandTest() {
        controllerInstance.setScanner(scanner);
        Assertions.assertDoesNotThrow(() -> {
            when(scanner.nextLine()).thenReturn("read TestDataBase").thenReturn("quit");
            Main.main(new String[0]);
        });
        Assertions.assertNotEquals(Database.getData(), 0);
    }

    @Test
    public void searchCommand() {
        controllerInstance.setScanner(scanner);
        Assertions.assertDoesNotThrow(() -> {
            when(scanner.nextLine()).thenReturn("read TestDataBase").thenReturn("read TestDataBase2")
            .thenReturn("search mir").thenReturn("quit");
            Main.main(new String[0]);
        });
        Assertions.assertNotEquals(Database.getData(), 0);
    }

    @Test
    public void advancedSearchCommand() {
        controllerInstance.setScanner(scanner);
        Assertions.assertDoesNotThrow(() -> {
            when(scanner.nextLine()).thenReturn("read TestDataBase").thenReturn("read TestDataBase2")
            .thenReturn("search +mir -mohammad gorbe").thenReturn("quit");
            Main.main(new String[0]);
        });
        Assertions.assertNotEquals(Database.getData(), 0);
    }
}
