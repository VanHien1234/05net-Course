namespace exercise_2.Exercises;

public class Exercise04
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 4 ");

        while (true)
            {
                Console.Write("age: ");
                const int Min = 18;
                const int Max = 27;
                string? input = Console.ReadLine();
                int selected;
                bool isInteger = int.TryParse(input, out selected);
                if (!isInteger)
                {
                    Console.WriteLine("retry! Please enter integer.");
                    continue;
                }


                if (selected < Min)
                {
                    Console.WriteLine("Chưa đủ tuổi tham gia NVQS");
                    return;
                }
                else if (selected > Max)
                {
                    Console.WriteLine("Quá tuổi tham gia NVQS");
                    return;
                }
                else
                {
                    Console.WriteLine("Đủ tuổi tham gia NVQS");
                    return;
                }
            }

    }
}



