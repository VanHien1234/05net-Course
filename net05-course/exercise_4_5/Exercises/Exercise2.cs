namespace exercise_4.Exercises;


public class Exercise2
{

    public static void Run()
    {
        List<string> lstStrings = new List<string> { "apple", "banana", "orange", "kiwi", "mango", "pineapple", "grape", "melon" };

        Console.WriteLine("lstStrings = [apple, banana, orange, kiwi, mango, pineapple, grape, melon]");
        Console.WriteLine();

        Console.WriteLine("1: Tính độ dài của mảng");
        Console.WriteLine($"result 1: {lstStrings.Count}");
        Console.WriteLine();

        Console.WriteLine("2: In ra các chuỗi dài hơn 5 ký tự");
        List<string> longerThan5 = ChuoiDaiHon5(lstStrings);
        Console.Write("result 2: ");
        Console.WriteLine(string.Join(", ", longerThan5));
        Console.WriteLine();

        Console.WriteLine("3: Tìm chuỗi dài nhất trong mảng");
        string longest = TimChuoiDaiNhat(lstStrings);
        Console.WriteLine($"result 3: {longest}");
        Console.WriteLine();

        Console.WriteLine("4: In ra các chuỗi có chứa chữ 'a'");
        List<string> withA = ChuoiChuaChuA(lstStrings);
        Console.Write("result 4: ");
        Console.WriteLine(string.Join(", ", withA));
        Console.WriteLine();

        Console.WriteLine("5: Tìm chuỗi bắt đầu bằng chữ 'm'");
        string startsWithM = TimChuoiBatDauBangM(lstStrings);
        Console.WriteLine($"result 5: {startsWithM}");
        Console.WriteLine();

        Console.WriteLine("6: Đếm số chuỗi có độ dài nhỏ hơn 6 ký tự");
        int countLessThan6 = DemChuoiNhoHon6(lstStrings);
        Console.WriteLine($"result 6: {countLessThan6}");
        Console.WriteLine();

        Console.WriteLine("7: In ra chuỗi dài thứ hai trong mảng");
        string secondLongest = TimChuoiDaiThuHai(lstStrings);
        Console.WriteLine($"result 7: {secondLongest}");
        Console.WriteLine();

        Console.WriteLine("9: Chuyển tất cả các chuỗi thành chữ hoa");
        List<string> uppercase = ChuyenTatCaThanhChuHoa(lstStrings);
        Console.Write("result 9: ");
        Console.WriteLine(string.Join(", ", uppercase));
        Console.WriteLine();

        Console.WriteLine("10: Thay thế chuỗi 'banana' bằng 'pear'");
        List<string> replaced = ThayTheBananaBangPear(lstStrings);
        Console.Write("result 10: ");
        Console.WriteLine(string.Join(", ", replaced));
        Console.WriteLine();
    }

    private static List<string> ChuoiDaiHon5(List<string> strings)
    {
        List<string> result = new List<string>();

        foreach (string str in strings)
        {
            if (str.Length > 5)
            {
                result.Add(str);
            }
        }

        return result;
    }

    private static string TimChuoiDaiNhat(List<string> strings)
    {
        string result = strings[0];

        foreach (string str in strings)
        {
            if (str.Length > result.Length)
            {
                result = str;
            }
        }

        return result;
    }

    private static List<string> ChuoiChuaChuA(List<string> strings)
    {
        List<string> result = new List<string>();

        foreach (string str in strings)
        {
            if (str.Contains('a'))
            {
                result.Add(str);
            }
        }

        return result;
    }

    private static string TimChuoiBatDauBangM(List<string> strings)
    {
        foreach (string str in strings)
        {
            if (str.StartsWith("m"))
            {
                return str;
            }
        }

        return "";
    }

    private static int DemChuoiNhoHon6(List<string> strings)
    {
        int count = 0;

        foreach (string str in strings)
        {
            if (str.Length < 6)
            {
                count = count + 1;
            }
        }

        return count;
    }

    private static string TimChuoiDaiThuHai(List<string> strings)
    {
        string max = strings[0].Length > strings[1].Length ? strings[0] : strings[1];
        string secondMax = strings[0].Length > strings[1].Length ? strings[1] : strings[0];
        for (int i = 2; i < strings.Count; i++)
        {
            if (strings[i].Length > max.Length)
            {
                secondMax = max;
                max = strings[i];
            }
            else if (strings[i].Length > secondMax.Length && strings[i] != max)
            {
                secondMax = strings[i];
            }
        }
        return secondMax;
    }

    private static List<string> ChuyenTatCaThanhChuHoa(List<string> strings)
    {
        List<string> result = new List<string>();

        foreach (string str in strings)
        {
            result.Add(str.ToUpper());
        }

        return result;
    }

    private static List<string> ThayTheBananaBangPear(List<string> strings)
    {
        List<string> result = new List<string>();

        foreach (string str in strings)
        {
            if (str == "banana")
            {
                result.Add("pear");
            }
            else
            {
                result.Add(str);
            }
        }

        return result;
    }



}
