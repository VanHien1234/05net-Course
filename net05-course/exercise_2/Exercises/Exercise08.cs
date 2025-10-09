namespace exercise_2.Exercises;

public class Exercise08
{
    public static void Run()
    {
        Console.WriteLine("+ Bài tập 8");
        
        const double Min = 2;
        const double Max = 5;
        
        while (true)
        {
            Console.Write("Quãng đường (km):   -- 0: exit ");
            Console.WriteLine("");
            string? input = Console.ReadLine();
            Console.WriteLine("KM");
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
                Console.WriteLine(selected * 10000 + " VND");
            }
            else if (selected > Max)
            {
                Console.WriteLine(selected * 6000 + " VND");
            }
            else
            {
                Console.WriteLine(selected * 8000 + " VND");
            }
        }
    }
}



