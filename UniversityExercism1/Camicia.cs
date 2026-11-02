using System;
using System.Collections.Generic;
using System.Linq;

public static class Camicia
{
    public enum GameStatus
    {
        Finished,
        Loop
    }

    public record GameResult(
        GameStatus Status,
        int Tricks,
        int Cards
    );

    public static GameResult SimulateGame(
        string[] playerA,
        string[] playerB)
    {
        var decks = new[]
        {
            new Queue<char>(playerA.Select(Normalize)),
            new Queue<char>(playerB.Select(Normalize))
        };

        var pile = new List<char>();
        var seen = new HashSet<string>();

        int cards = 0;
        int tricks = 0;
        int current = 0;
        int lastPaymentPlayer = -1;
        int penalty = 0;

        while (true)
        {
            if (pile.Count == 0)
            {
                string state = GetState(decks, current);

                if (!seen.Add(state))
                    return new GameResult(
                        GameStatus.Loop, tricks, cards);
            }

            if (decks[current].Count == 0)
            {
                int winner = 1 - current;

                if (pile.Count > 0)
                {
                    Collect(decks[winner], pile);
                    tricks++;
                }

                return new GameResult(
                    GameStatus.Finished, tricks, cards);
            }

            char card = decks[current].Dequeue();
            pile.Add(card);
            cards++;

            int payment = GetPayment(card);

            if (payment > 0)
            {
                penalty = payment;
                lastPaymentPlayer = current;
                current = 1 - current;
                continue;
            }

            if (penalty > 0)
            {
                penalty--;

                if (penalty == 0)
                {
                    int winner = lastPaymentPlayer;
                    Collect(decks[winner], pile);
                    tricks++;

                    if (decks[1 - winner].Count == 0)
                        return new GameResult(
                            GameStatus.Finished, tricks, cards);

                    current = winner;
                    lastPaymentPlayer = -1;
                }
            }
            else
            {
                current = 1 - current;
            }
        }
    }

    private static char Normalize(string card)
    {
        return card switch
        {
            "J" => 'J',
            "Q" => 'Q',
            "K" => 'K',
            "A" => 'A',
            _ => '-'
        };
    }

    private static int GetPayment(char card) => card switch
    {
        'J' => 1,
        'Q' => 2,
        'K' => 3,
        'A' => 4,
        _ => 0
    };

    private static void Collect(
        Queue<char> deck,
        List<char> pile)
    {
        foreach (char card in pile)
            deck.Enqueue(card);

        pile.Clear();
    }

    private static string GetState(
        Queue<char>[] decks,
        int current)
    {
        return current + "|" +
               new string(decks[0].ToArray()) + "|" +
               new string(decks[1].ToArray());
    }
}
