//casino-game

string[] gameMode = new string[] { "easy", "medium", "hard" };
List<List<string>> invisiblePath = new List<List<string>>();
List<string> visiblePath = new List<string>() { "[]", "[]", "[]", "[]", "[]" };
string output = "";
int currLine = 0;
bool cont = true;
int bet = 0;
int credits = 500;
bool win = true;

gameModel(chooseGameMode(gameMode));

foreach (var line in invisiblePath)
{
    currLine++;
    if (cont == false) 
    {
        Console.WriteLine("You lost!");
        credits -= bet;
        win = false;
        break;
    }
    Console.Clear();
    int position = 0;
    for (int i = 0; i < visiblePath.Count; i++)
    {
        if (i == position)
        {
            Console.Write("> " + visiblePath[i]);
        }
        else
        {
            Console.Write(visiblePath[i]);
        }
    }
    while (true)
    {
        ConsoleKeyInfo keyInput = Console.ReadKey();
        if (keyInput.Key == ConsoleKey.RightArrow)
        {
            Console.Clear();
            position++;
            if (position > visiblePath.Count - 1)
            {
                position = visiblePath.Count - 1;
            }
            for (int i = 0; i < visiblePath.Count; i++)
            {
                if (i == position)
                {
                    Console.Write("> " + visiblePath[i]);
                }
                else
                {
                    Console.Write(visiblePath[i]);
                }
            }
        }
        else if (keyInput.Key == ConsoleKey.LeftArrow)
        {
            Console.Clear();
            position--;
            if (position < 0)
            {
                position = 0;
            }
            for (int i = 0; i < visiblePath.Count; i++)
            {
                if (i == position)
                {
                    Console.Write("> " + visiblePath[i]);
                }
                else
                {
                    Console.Write(visiblePath[i]);
                }
            }
        }
        else if (keyInput.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            if (line[position] == "[X]")
            {
                cont = false;
                break;
            }
            break;
        }
    }
}
if (win)
{
    credits = credits + (bet * 2);
    Console.WriteLine("You Won");
}

void gameModel(string gameMode) 
{
    if (gameMode == "easy")
    {
        for (int i = 0; i < 6; i++)
        {
            Random random = new Random();
            int index = random.Next(5);
            List<string> list = new List<string>() { "[]", "[]", "[]", "[]", "[]" };
            list[index] = "[X]";
            invisiblePath.Add(list);
            bet = 20;
        }
    }
    else if (gameMode == "medium") 
    {
        for (int i = 0; i < 8; i++)
        {
            Random random = new Random();
            int index = random.Next(5);
            List<string> list = new List<string>() { "[]", "[]", "[]", "[]", "[]" };
            list[index] = "[X]";
            invisiblePath.Add(list);
            bet = 50;
        }
    }
    else if (gameMode == "hard")
    {
        for (int i = 0; i < 10; i++)
        {
            Random random = new Random();
            int index = random.Next(5);
            List<string> list = new List<string>() { "[]", "[]", "[]", "[]", "[]" };
            list[index] = "[X]";
            invisiblePath.Add(list);
            bet = 100;
        }
    }
}

string chooseGameMode(string[] gameMode) 
{
    int position = 0;
    foreach (var item in gameMode)
    {
        if (item == gameMode[position])
        {
            Console.WriteLine("> " + item);
        }
        else
        {
            Console.WriteLine(item);
        }
    }

    while (true)
    {
        ConsoleKeyInfo keyInput = Console.ReadKey();
        if (keyInput.Key == ConsoleKey.DownArrow)
        {
            Console.Clear();
            position++;
            if (position > gameMode.Length - 1)
            {
                position = gameMode.Length - 1;
            }
            foreach (var item in gameMode)
            {
                if (item == gameMode[position])
                {
                    Console.WriteLine("> " + item);
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }
        else if (keyInput.Key == ConsoleKey.UpArrow)
        {
            Console.Clear();
            position--;
            if (position < 0)
            {
                position = 0;
            }
            foreach (var item in gameMode)
            {
                if (item == gameMode[position])
                {
                    Console.WriteLine("> " + item);
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
        }
        else if (keyInput.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            Console.WriteLine("You chose " + gameMode[position]);
            return gameMode[position];
        }
    }
}