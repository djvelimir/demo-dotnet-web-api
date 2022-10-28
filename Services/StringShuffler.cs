using DemoDotnetWebApi.Interfaces;

namespace DemoDotnetWebApi.Services;

public class StringShuffler : IStringShuffler
{
    private readonly Random random = new Random();

    public string Shuffle(string characters)
    {
        IList<string> list = characters.Split("").ToList();
        int n = list.Count;

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            string value = list[k];
            list[k] = list[n];
            list[n] = value;
        }

        return string.Join("", list);
    }
}
