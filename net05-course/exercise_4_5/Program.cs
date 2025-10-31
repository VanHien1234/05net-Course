using exercise_4.Exercises;


while (true)
{
    Console.WriteLine("***input (1)  --  lstNumber = [20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20]");
    Console.WriteLine("***input (2)  --  lstStrings = [apple, banana, orange, kiwi, mango, pineapple, grape, melon]");
    Console.WriteLine("*** 0 : exit");

    Console.Write("select: ");

    string input = Console.ReadLine();

    bool isInteger = int.TryParse(input, out int selected);

    if (!isInteger)
    {
        Console.WriteLine("retry!");
        continue;
    }
    Console.WriteLine("");

    switch (selected)
    {
        case 0:
            Console.WriteLine("exit");
            return;
        case 1:
            Exercise1.Run();
            break;
        case 2:
            Exercise2.Run();
            break;
        default:
            Console.WriteLine("retry!");
            break;
    }
}

