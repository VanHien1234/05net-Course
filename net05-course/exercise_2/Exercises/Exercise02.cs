namespace exercise_2.Exercises;

public class Exercise02
{
    public static void Run()
    {
        {
            Console.WriteLine("+ Bài tập 2 ");

            while (true)
            {
                Console.Write("income money: ");
                const int MinTax = 5000000;
                const int MaxTax = 10000000;
                string? input = Console.ReadLine();
                int selected;
                bool isInteger = int.TryParse(input, out selected);
                if (!isInteger)
                {
                    Console.WriteLine("retry! Please enter integer.");
                    continue;
                }


                if (selected <= MinTax)
                {
                    Console.WriteLine("tax: 0 VND");
                    return;
                }
                else if (selected > MaxTax)
                {
                    Console.WriteLine("tax: " + selected * 0.2 + "VND");
                    return;
                }
                else
                {
                    Console.WriteLine("tax: " + selected * 0.1 + "VND");
                    return;
                }
            }
        }
    }
}

