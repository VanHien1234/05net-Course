namespace exercise_2.Exercises;

public class Exercise05
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 5");

        while (true)
        {
            Console.Write("Nhập số nguyên :   -- 0: exit");
            string? input = Console.ReadLine();
            
            int number;
            bool isInteger = int.TryParse(input, out number);
            
            if (!isInteger)
            {
                Console.WriteLine("retry! enter integer.");
                continue;
            }

            if (number == 0)
            {
                Console.WriteLine("exit!");
                return;
            }

            // Kiểm tra số nguyên tố
            if (checkSNT(number))
            {
                Console.WriteLine($"{number} là số nguyên tố ");
            }
            else
            {
                Console.WriteLine($"{number} không phải số nguyên tố ");
            }

        }
    }

    private static bool checkSNT(int n)
    {
        if (n <= 1)
        {
            return false;
        }
        for (int i = 2; i < n; i = i + 1)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}

