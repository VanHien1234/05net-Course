using exercise_2.Exercises;


while (true)
{
    Console.WriteLine("***input (1-10)  -- 0 : exit");
    Console.Write("select: ");

    string input = Console.ReadLine();
    int selected;
    bool isInteger = int.TryParse(input, out selected);

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
            Exercise01.Run();
            break;
        case 2:
            Exercise02.Run();
            break;
        case 3:
            Exercise03.Run();
            break;
        case 4:
            Exercise04.Run();
            break;
        case 5:
            Exercise05.Run();
            break;
        case 6:
            Exercise06.Run();
            break;
        case 7:
            Exercise07.Run();
            break;
        case 8:
            Exercise08.Run();
            break;
        case 9:
            Exercise09.Run();
            break;
        case 10:
            Exercise10.Run();
            break;
        default:
            Console.WriteLine("retry!");
            break;
    }
}
