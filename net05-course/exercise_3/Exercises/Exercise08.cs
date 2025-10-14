namespace exercise_3.Exercises;

public class Exercise08
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 8:  --- 0 : exit");
        while (true)
        {
            Console.WriteLine("Input string: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int selected) && selected == 0)
            {
                Console.WriteLine("exit!");
                return;
            }
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("retry!");
                continue;
            }
            string result = FindLongestWordHasNumber(input);
            Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }
    }

    private static string FindLongestWordHasNumber(string str)
    {
        string[] words = str.Split(' ');

        string result = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > result.Length && IsHasNumber(words[i]))
            {
                result = words[i];
            }
        }
        return result;
    }

    private static bool IsHasNumber(string str)
    {

        foreach (char item in str)
        {
            bool isNumber = char.IsNumber(item);
            if (isNumber)
            {
                return true;
            }
        }
        return false;
    }
}
