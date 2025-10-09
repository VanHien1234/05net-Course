namespace exercise_2.Exercises;

public class Exercise10
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 10");

        while (true)
        {
            Console.Write("Nhập loại vé :  ");
            Console.WriteLine("(Economy :   (1)");
            Console.WriteLine("Business :   (2)");
            Console.WriteLine("First Class :   (3)");
            Console.WriteLine("0: exit");
            string? input = Console.ReadLine();
            
            int type;
            bool isInteger = int.TryParse(input, out type);
            if (!isInteger)
            {
                Console.WriteLine("retry! enter integer.");
                continue;
            }

            if (type == 0)
            {
                Console.WriteLine("exit!");
                return;
            }

            switch (type)
            {
                case 1:
                    Console.WriteLine("Ghế thường");
                    break;
                case 2:
                    Console.WriteLine("Ghế rộng");
                    break;
                case 3:
                    Console.WriteLine("Ghế sang trọng");
                    break;
                default:
                    Console.WriteLine("retry!");
                    break;
            }

        }
    }
}



