Console.WriteLine("Program Loaded");
Console.WriteLine("How many times would you like the simulation to run?");
int Years = Convert.ToInt32(Console.ReadLine());
string[,] Board = new string[36,20];
int RanYears = 0;
int currentSeason = 0;
string currentSeasonString = "Spring";
bool Finished = YearCheck(Years, RanYears, currentSeason);
Board = setupGame(Years, Board);

while (Finished == false)
{
    RanYears = Spring(Board, RanYears);
    printBoard(Board, currentSeasonString, RanYears);
    currentSeason = SeasonUpdate(Years, RanYears, currentSeason);
    currentSeasonString = SeasonStringUpdate(currentSeason, currentSeasonString);
    Autum(Board);
    currentSeason = SeasonUpdate(Years, RanYears, currentSeason);
    currentSeasonString = SeasonStringUpdate(currentSeason, currentSeasonString);
    printBoard(Board, currentSeasonString, RanYears);
    currentSeason = SeasonUpdate(Years, RanYears, currentSeason);
    currentSeasonString = SeasonStringUpdate(currentSeason, currentSeasonString);
    Winter(Board);
    printBoard(Board, currentSeasonString, RanYears);
    Finished = YearCheck(Years, RanYears, currentSeason);
}

static string[,] setupGame(int Years, string[,] b)
{
    for (int i = 0; i < 20; i++)
    {
        for (int x = 0; x < 36; x++)
        {
            b[x, i] = ".";
        }
    }
    b[18, 11] = "S";
    Console.WriteLine("This is the starting board");
    for (int row = 0; row < 20; row++)
    {
        for (int col = 0; col < 36; col++)
        {
            Console.Write(b[col, row]);
        }
        Console.WriteLine();
    }
    return b;
}

static void printBoard(string[,] b, string currentSeasonString, int RanYears)
{
    Console.WriteLine("This is the board in: {0}, year {1}", currentSeasonString, RanYears);
    for (int row = 0; row < 20; row++)
    {
        for (int col = 0; col < 36; col++)
        {
        Console.Write(b[col, row]);
        }
    Console.WriteLine();
        
    }
    Console.WriteLine("Please any key to continue.");
    Console.ReadLine();
}

static int SeasonUpdate(int Years, int RanYears, int currentSeason)
{
    currentSeason++;
    if (currentSeason >= 3)
    {
        currentSeason = 0;
    }
    return currentSeason;
}

static string SeasonStringUpdate(int currentSeason, string currentSeasonString)
{
    if (currentSeason == 0)
    {
        currentSeasonString = "Winter";
    }
    else if (currentSeason == 1)
    {
        currentSeasonString = "Spring";
    }
    else if (currentSeason == 2)
    {
        currentSeasonString = "Autum";
    }
    return currentSeasonString;
}

static bool YearCheck(int Years, int RanYears, int currentSeason)
{
    bool Finished;
    if (RanYears > Years)
    {
        Finished = true;
    }
    else
    {
        Finished = false;
    }
    return Finished;
}

static int Spring(string[,] b, int RanYears)
{
    for (int i = 0; i < 20; i++)
    {
        for (int x = 0; x < 36; x++)
        {
            if (b[x, i] == "S")
            {
                b[x, i] = "P";
            }
            else if (b[x, i] == "X")
            {
                b[x, i] = "X";
            }
            else if (b[x, i] == "P")
            {
                b[x, i] = "P";
            }
            else
            {
                b[x, i] = ".";
            }
        }
    }
    RanYears++;
    return RanYears;
}

static void Autum(string[,] b)
{
    for (int i = 0; i < 20; i++)
    {
        for (int x = 0; x < 36; x++)
        {
            if (b[x, i] == "P")
            {
                b[x, (i + 1)] = "S";
                b[(x - 1), i] = "S";
                b[(x - 1), (i - 1)] = "S";
                b[(x + 1), (i + 1)] = "S";
                b[x, (i - 1)] = "S";
                b[(x + 1), i] = "S";
                b[(x - 1), (i + 1)] = "S";
                b[(x + 1), (i - 1)] = "S";
            }
        }
    }
}

static void Winter(string[,] b)
{
    for (int i = 0; i < 20; i++)
    {
        for (int x = 0; x < 36; x++)
        {
            if (b[x, i] == "P")
            {
                b[x, i] = ".";
            }
        }
    }
}