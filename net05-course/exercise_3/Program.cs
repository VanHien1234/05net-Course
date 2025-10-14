using exercise_3.Exercises;


while (true)
{
    Console.WriteLine("***input (6-8)  -- 0 : exit");
    Console.Write("select: ");

    // int input = Convert.ToInt32(Console.ReadLine());
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
        case 6:
            Exercise06.Run();
            break;
        case 7:
            Exercise07.Run();
            break;
        case 8:
            Exercise08.Run();
            break;
        default:
            Console.WriteLine("retry!");
            break;
    }
}

