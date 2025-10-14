namespace exercise_3.Exercises;

public class Exercise07
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 7:  --- 0 : exit");
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
            string result = RemoveSpecialCharacter(input);
            Console.WriteLine("Result: " + result);
            Console.WriteLine();
        }
    }

    private static string RemoveSpecialCharacter(string str)
    {
        string resultString = "";
        foreach (char item in str)
        {
            bool isLetter = char.IsLetter(item);
            bool isNumber = char.IsNumber(item);
            bool isSpace = (item == ' ');
            if (isLetter || isSpace || isNumber)
            {
                resultString = resultString + item;
            }
        }
        return resultString;
    }
}
