using System;
using System.Collections.Generic;
using System.Linq;

internal class Bankoplade
{
    public string Id { get; }
    public List<List<int>> Rækker { get; }


    // Bankoplade-klassen viser en bankoplade med et unikt ID og en liste af talrækker.
    public Bankoplade(string id, List<List<int>> rækker)
    {
        Id = id;
        Rækker = rækker;
    }


    // KrydsAf-metoden markerer et bestemt nummer på bankopladen ved at ændre det til 0.
    public void KrydsAf(int nummer)
    {
        for (int række = 0; række < Rækker.Count; række++)
        {
            for (int kolonne = 0; kolonne < Rækker[række].Count; kolonne++)
            {
                if (Rækker[række][kolonne] == nummer)
                {
                    Rækker[række][kolonne] = 0; // Kryds af tallet.
                }
            }
        }
    }

    // HarVundetRække-metoden tjekker, om en specifik række på bankopladen er blevet vundet (alle tal er krydset af).
    public bool HarVundetRække(int rækkeIndex)
    {
        return Rækker[rækkeIndex].All(tal => tal == 0);
    }

    public bool HarVundetPlade()
    {
        return Rækker.All(række => række.All(tal => tal == 0));
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Bankoplade> bankplader = new List<Bankoplade>();
        List<List<List<int>>> bankopladerTal = new List<List<List<int>>>
        {
            // Definition af de fem bankoplader med talrækker.
            // Hver række er en liste af tal fra 1 til 90.
            new List<List<int>>
            {
                new List<int> { 3, 25, 45, 72, 85 },
                new List<int> { 26, 33, 46, 63, 73 },
                new List<int> { 7, 19, 58, 67, 78 }
            },
            new List<List<int>>
            {
                new List<int> { 4, 12, 57, 70, 82 },
                new List<int> { 6, 14, 26, 58, 64 },
                new List<int> { 15, 29, 38, 48, 76 }
            },
            new List<List<int>>
            {
                new List<int> { 23, 34, 40, 70, 83 },
                new List<int> { 11, 27, 52, 65, 75 },
                new List<int> { 9, 29, 39, 66, 76 }
            },
            new List<List<int>>
            {
                new List<int> { 4, 36, 40, 54, 70 },
                new List<int> { 13, 26, 47, 62, 84 },
                new List<int> { 19, 29, 48, 77, 89 }
            },
            new List<List<int>>
            {
                new List<int> { 41, 50, 60, 71, 83 },
                new List<int> { 4, 15, 25, 34, 54 },
                new List<int> { 5, 17, 26, 66, 89 }
            }
        };

        // Hvis antallet af bankoplader ikke er 5 eller mere, udskriver vi en fejlmeddelelse.
        if (bankopladerTal.Count != 5)
        {
            Console.WriteLine("Antallet af bankoplader skal være minimum 5.");
            return;
        }


        // Beder brugeren om at indtaste et unikt ID for hver bankoplade.
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Indtast ID for bankoplade " + (i + 1) + ": ");
            string id = Console.ReadLine();
            Bankoplade nyBankplade = new Bankoplade(id, bankopladerTal[i]);
            Console.WriteLine("Færdig plade for " + id + ":");


            // Opretter en ny bankoplade med det indtastede ID og de tilhørende talrækker.
            for (int række = 0; række < 3; række++)
            {
                Console.Write("Række " + (række + 1) + ": ");
                for (int kolonne = 0; kolonne < 5; kolonne++)
                {
                    int nummer = nyBankplade.Rækker[række][kolonne];
                    string symbol = (nummer == 0) ? "X" : nummer.ToString();
                    Console.Write(symbol.PadLeft(3, ' ') + " ");
                }
                Console.WriteLine();
            }
            bankplader.Add(nyBankplade);
        }


        // Starter en løkke, der fortsætter, indtil brugeren indtaster -1
        int råbtTal;
        Console.WriteLine("Nu kan du begynde at skrive tal ind der bliver råbt op!");
        Console.WriteLine("Held og lykke! Og husk det er kun snyd, hvis det bliver opdaget ;)");
        while ((råbtTal = Convert.ToInt32(Console.ReadLine())) != -1)
        {
            foreach (Bankoplade plade in bankplader)
            {
                plade.KrydsAf(råbtTal);
                bool harVundetRække = false;
                bool harVundetPlade = false;

                for (int rækkeIndex = 0; rækkeIndex < plade.Rækker.Count; rækkeIndex++)
                {
                    if (plade.HarVundetRække(rækkeIndex))
                    {
                        Console.WriteLine($"{plade.Id} har banko på række {rækkeIndex + 1}!");
                        harVundetRække = true;
                    }
                }

                if (plade.HarVundetPlade())
                {
                    Console.WriteLine(plade.Id + " har banko på hele pladen!");
                    harVundetPlade = true;
                }

                if (harVundetRække && !harVundetPlade)
                {
                    Console.WriteLine(plade.Id + " har vundet mindst én række, men ikke hele pladen.");
                }
            }
        }
    }
}
