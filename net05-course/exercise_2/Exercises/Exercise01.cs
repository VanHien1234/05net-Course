namespace exercise_2.Exercises;

public class Exercise01
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 1 ");

        while (true)
        {
            Console.Write("Temp: ");
            string? input = Console.ReadLine();
            int selected;
            bool isInteger = int.TryParse(input, out selected);
            if (!isInteger)
            {
                Console.WriteLine("retry! Please enter integer.");
                continue;
            }
            if (selected == 0)
            {
                Console.WriteLine(" Trời rất lạnh, đúng 0°C!");
                return;
            }
            else if (selected < 0)
            {
                Console.WriteLine(" Trời lạnh, có thể có băng giá!");
                return;
            }
            else if (selected > 0)
            {
                Console.WriteLine(" Trời ấm");
                return;
            }
        }
    }
}

