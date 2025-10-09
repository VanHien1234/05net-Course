namespace exercise_2.Exercises;

public class Exercise06
{
    public static void Run()
    {
        Console.WriteLine("+Bài tập 6");
        
        const double Min = 100;
        const double Max = 200;
        
        while (true)
        {
            Console.Write("Mức tiêu thụ (km):   -- 0: exit ");
            Console.WriteLine("");
            string? input = Console.ReadLine();
            Console.WriteLine("KWH");
            double selected;
            bool isDouble = double.TryParse(input, out selected);
            
            if (!isDouble || selected < 0)
            {
                Console.WriteLine("retry! Please enter number.");
                continue;
            }
            
            if (selected == 0)
            {
                Console.WriteLine("exit");
                return;
            }

            if (selected < Min)
            {
                Console.WriteLine( selected * 1.500 + "VND");
            }
            else if (selected >Max)
            {
                Console.WriteLine(selected * 2.500 + " VND");
            }
            else
            {
                Console.WriteLine(selected * 2.000 + " VND");
            }
        }


    }
}



