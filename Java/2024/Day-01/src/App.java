import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.util.ArrayList;

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

        var list1 = new ArrayList<Integer>();
        var list2 = new ArrayList<Integer>();

        for (String line : lines) {
            var parts = line.split("   ");
            list1.add(Integer.parseInt(parts[0]));
            list2.add(Integer.parseInt(parts[1]));
        }

        list1.sort(null);
        list2.sort(null);

        for (int i = 0; i < list1.size(); i++) {
            result += Math.abs(list1.get(i) - list2.get(i));
        }

        return result;
    }

    public static int part2(String[] lines) {
        int result = 0;

        var list1 = new ArrayList<Integer>();
        var list2 = new ArrayList<Integer>();

        for (String line : lines) {
            var parts = line.split("   ");
            list1.add(Integer.parseInt(parts[0]));
            list2.add(Integer.parseInt(parts[1]));
        }

        for (int i = 0; i < list1.size(); i++) {
            var item = list1.get(i);

            var count = 0;
            for (int j = 0; j < list2.size(); j++) {
                if (list2.get(j).equals(item)) {
                    count++;
                }
            }
            result += count * item;
        }

        return result;
    }
}