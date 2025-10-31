namespace exercise_4.Exercises;


public class Exercise1
{

    public static void Run()
    {
        
        List<int> LstNumber = new List<int> { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };
        Console.WriteLine("lstNumber = [20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20]");
        Console.WriteLine();

        Console.WriteLine("1: ");
        int sum1 = SumNumbersGreaterThan50(LstNumber);
        Console.WriteLine($"result 1: {sum1}");
        Console.WriteLine();

        Console.WriteLine("2:");
        int count2 = CountNumbersGreaterThan30(LstNumber);
        Console.WriteLine($"result 2: {count2}");
        Console.WriteLine();

        Console.WriteLine("3:");
        int max = FindMaxNumber(LstNumber);
        Console.WriteLine($"result 3: {max}");
        Console.WriteLine();

        Console.WriteLine("4:");
        double average = TrungBinhCongSoLe(LstNumber);
        Console.WriteLine($"result 4: {average}");
        Console.WriteLine();

        Console.WriteLine("5:");
        List<int> evenNumbers = DanhSachSoChan(LstNumber);
        Console.Write("result 5: ");
        Console.WriteLine( string.Join(", ", evenNumbers));
        Console.WriteLine();

        Console.WriteLine("6:");
        int index = FindFirstIndexOf20(LstNumber);
        if (index != -1)
        {
            Console.WriteLine($"result 6: {index}");
        }

        Console.WriteLine();

        Console.WriteLine("7:");
        int count7 = CountNumbersEqualTo15(LstNumber);
        Console.WriteLine($"result 7: {count7}");
        Console.WriteLine();

        Console.WriteLine("8:");
        int sum8 = SumNumbersLessThan40(LstNumber);
        Console.WriteLine($"result 8: {sum8}");
        Console.WriteLine();

        Console.WriteLine("9:");
        int count9 = DemCacSoChiaHetCho5(LstNumber);
        Console.WriteLine($"result 9: {count9}");
        Console.WriteLine();

        Console.WriteLine("10:");
        List<int> newList = ListLessThan50(LstNumber);
        Console.Write("result 10: ");
        Console.WriteLine( string.Join(", ", newList));
        Console.WriteLine();
    }



    private static int SumNumbersGreaterThan50(List<int> numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            if (number > 50)
            {
                sum = sum + number;
            }
        }
        return sum;
    }

    private static int CountNumbersGreaterThan30(List<int> numbers)
    {
        int count = 0;
        foreach (int number in numbers)
        {
            if (number > 30)
            {
                count = count + 1;
            }
        }
        return count;
    }

    private static int FindMaxNumber(List<int> numbers)
    {
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        return max;
    }

    private static double TrungBinhCongSoLe(List<int> numbers)
    {
        int sum = 0;
        int count = 0;

        foreach (int number in numbers)
        {
            if (number % 2 == 1)
            {
                sum = sum + number;
                count = count + 1;
            }
        }

        if (count == 0)
        {
            return 0;
        }

        double average = (double)sum / count;
        return average;
    }

    private static List<int> DanhSachSoChan(List<int> numbers)
    {
        List<int> resultList = new List<int>();

        foreach (int number in numbers)
        {
            if (number % 2 == 0)
            {
                resultList.Add(number);
            }
        }

        return resultList;
    }

    private static int FindFirstIndexOf20(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] == 20)
            {
                return i;
            }
        }
        return -1;
    }

    private static int CountNumbersEqualTo15(List<int> numbers)
    {
        int count = 0;

        foreach (int number in numbers)
        {
            if (number == 15)
            {
                count = count + 1;
            }
        }

        return count;
    }

    private static int SumNumbersLessThan40(List<int> numbers)
    {
        int sum = 0;

        foreach (int number in numbers)
        {
            if (number < 40)
            {
                sum = sum + number;
            }
        }

        return sum;
    }

    private static int DemCacSoChiaHetCho5(List<int> numbers)
    {
        int count = 0;

        foreach (int number in numbers)
        {
            if (number % 5 == 0)
            {
                count = count + 1;
            }
        }

        return count;
    }

    private static List<int> ListLessThan50(List<int> numbers)
    {
        List<int> newList = new List<int>();

        foreach (int number in numbers)
        {
            if (number < 50)
            {
                newList.Add(number);
            }
        }

        return newList;
    }

}
