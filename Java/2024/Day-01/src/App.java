import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

public class App {
    public static void main(String[] args) {
        String filePath = "input.txt"; 

        String input = "";
        try {
            input = Files.readString(Path.of(filePath));
        } catch (IOException ignored) {
        }

        String[] lines = input.split("\n");

        System.out.println("Part 1: " + part1(lines));
        System.out.println("Part 2: " + part2(lines));
    }

    public static int part1(String[] lines) {
        int result = 0;
        for (String line : lines) {
            // Do something with the line
        }
        return result;
    }

    public static int part2(String[] lines) {
        int result = 0;
        for (String line : lines) {
            // Do something with the line
        }
        return result;
    }
}