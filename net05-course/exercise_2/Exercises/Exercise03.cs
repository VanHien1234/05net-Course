namespace exercise_2.Exercises;

public class Exercise03
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 3 ");

        while (true)
        {
            Console.Write("month: ");
            string? input = Console.ReadLine();
            int selected;
            bool isInteger = int.TryParse(input, out selected);
            if (!isInteger)
            {
                Console.WriteLine("retry! Please enter integer.");
                continue;
            }

            switch (selected)
            {
                case 0:
                    Console.WriteLine("exit!");
                    return;
                case 1:
                case 2:
                case 3:
                    Console.WriteLine("Xuân");
                    break;
                case 4:
                case 5:
                case 6:
                    Console.WriteLine("Hạ");
                    break;
                case 7:
                case 8:
                case 9:
                    Console.WriteLine("Thu");
                    break;
                case 10:
                case 11:
                case 12:
                    Console.WriteLine("Đông");
                    break;
                default:
                    Console.WriteLine("retry!");
                    break;
            }
        }
    }
}

