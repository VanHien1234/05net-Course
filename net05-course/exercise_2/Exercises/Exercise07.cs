namespace exercise_2.Exercises;

public class Exercise07
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 7");
                while (true)
        {
            Console.Write("Nhập loại vé :  ");
            Console.WriteLine("(Standard :   (1)");
            Console.WriteLine("Premium :   (2)");
            Console.WriteLine("VIP :   (3)");
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
                    Console.WriteLine("Ghế ngồi thường, không có đồ uống");
                    break;
                case 2:
                    Console.WriteLine("GGhế ngồi thoải mái, có đồ uống miễn phí");
                    break;
                case 3:
                    Console.WriteLine("Ghế ngồi hạng sang, có đồ uống và bỏng ngô miễn phí");
                    break;
                default:
                    Console.WriteLine("retry!");
                    break;
            }

        }

    }
}



