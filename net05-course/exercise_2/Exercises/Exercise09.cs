namespace exercise_2.Exercises;

public class Exercise09
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 9");

        while (true)
        {
            Console.Write("Nhập 1 ký tự:   -- 0: exit ");
            Console.WriteLine("");
            string input = Console.ReadLine();

            if (input == "0")
            {
                Console.WriteLine("exit");
                return;
            }

            if ( input?.Length != 1)
            {
                Console.WriteLine("retry! Vui lòng nhập đúng 1 ký tự.");
                continue;
            }

            char kyTuThuong = char.ToLower(input[0]);

            if (kyTuThuong == 'a' || 
                kyTuThuong == 'e' || 
                kyTuThuong == 'i' || 
                kyTuThuong == 'o' || 
                kyTuThuong == 'u')
            {
                Console.WriteLine("Là nguyên âm");
            }
            else
            {
                Console.WriteLine("Là phụ âm");
            }
        }
    }
}



