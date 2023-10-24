using System;
using System.Collections.Generic;
using System.Linq;

public class Bankplade
{
    public string Id { get; set; }
    public List<List<int>> Rækker { get; set; }

    public bool HarVundet(int nummer)
    {
        return Rækker.Any(række => række.All(tal => tal == nummer || (tal == 0 && nummer == 90)));
    }

    public bool HarVundetToRækker(int nummer)
    {
        int antalRækker = Rækker.Count(række => række.All(tal => tal == nummer || (tal == 0 && nummer == 90)));
        return antalRækker >= 2;
    }

    public bool HarVundetFuldPlade(int nummer)
    {
        return Rækker.All(række => række.All(tal => tal == nummer || (tal == 0 && nummer == 90)));
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Bankplade> bankplader = new List<Bankplade>();

        // Definition af tal til de 5 bankoplader
        List<List<List<int>>>
        bankopladerTal = new List<List<List<int>>>
        {
            new List<List<int>>
            {
                new List<int> { 1, 2, 3, 4, 5 },
                new List<int> { 6, 7, 8, 9, 10 },
                new List<int> { 11, 12, 13, 14, 15 }
            },
            new List<List<int>>
            {
                new List<int> { 16, 17, 18, 19, 20 },
                new List<int> { 21, 22, 23, 24, 25 },
                new List<int> { 26, 27, 28, 29, 30 }
            },
            new List<List<int>>
            {
                new List<int> { 31, 32, 33, 34, 35 },
                new List<int> { 36, 37, 38, 39, 40 },
                new List<int> { 41, 42, 43, 44, 45 }
            },
            new List<List<int>>
            {
                new List<int> { 46, 47, 48, 49, 50 },
                new List<int> { 51, 52, 53, 54, 55 },
                new List<int> { 56, 57, 58, 59, 60 }
            },
            new List<List<int>>
            {
                new List<int> { 61, 62, 63, 64, 65 },
                new List<int> { 66, 67, 68, 69, 70 },
                new List<int> { 71, 72, 73, 74, 75 }
            }
        };

