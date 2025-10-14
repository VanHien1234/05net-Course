namespace exercise_3.Exercises;

public class Exercise06
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 6:  --- 0 : exit");
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
            string result = FindLongestWord(input);
            Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }
    }

    private static string FindLongestWord(string str)
    {
        string[] words = str.Split(' ');

        string longestWord = words[0];
        for (int i = 1; i < words.Length; i++)
        {
            if (words[i].Length > longestWord.Length)
            {
                longestWord = words[i];
            }
        }
        return longestWord;
    }
}
