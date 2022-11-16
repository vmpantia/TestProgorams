


Dictionary<string, int> RomanNumerals = new Dictionary<string, int>()
{
    {"I", 1},
    {"IV", 4},
    {"V", 5},
    {"IX", 9},
    {"X", 10},
    {"XL", 40},
    {"L", 50},
    {"XC", 90},
    {"C", 100},
    {"CD", 400},
    {"D", 500},
    {"CM", 900},
    {"M", 1000},
};

RomanToInt("LVIII");

void RomanToInt(string s)
{
    var result = 0;

    char prevVal = ' ';

    s.ToArray().ToList().ForEach(x =>
    {
        if (x == 'I')
            result += RomanNumerals["I"];

        if (x == 'V')
            if (prevVal == 'I') {
                result -= RomanNumerals["I"];
                result += RomanNumerals["IV"];
            }
            else {
                result += RomanNumerals["V"];
            }

        if (x == 'X')
            if (prevVal == 'I')
            {
                result -= RomanNumerals["I"];
                result += RomanNumerals["IX"];
            }
            else
            {
                result += RomanNumerals["X"];
            }

        if (x == 'L')
            if (prevVal == 'X')
            {
                result -= RomanNumerals["X"];
                result += RomanNumerals["XL"];
            }
            else
            {
                result += RomanNumerals["L"];
            }

        if (x == 'C')
            if (prevVal == 'X')
            {
                result -= RomanNumerals["X"];
                result += RomanNumerals["XC"];
            }
            else
            {
                result += RomanNumerals["C"];
            }

        if (x == 'D')
            if (prevVal == 'C')
            {
                result -= RomanNumerals["C"];
                result += RomanNumerals["CD"];
            }
            else
            {
                result += RomanNumerals["D"];
            }
        if (x == 'M')
            if (prevVal == 'C')
            {
                result -= RomanNumerals["C"];
                result += RomanNumerals["CM"];
            }
            else
            {
                result += RomanNumerals["M"];
            }

        prevVal = x;
    });

    Console.WriteLine(result);
}