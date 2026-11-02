using System;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target < 0)
            throw new ArgumentException("The target cannot be negative.", nameof(target));

        var counts = new int[target + 1];
        var lastCoin = new int[target + 1];
        Array.Fill(counts, int.MaxValue);
        counts[0] = 0;

        for (int amount = 1; amount <= target; amount++)
        {
            foreach (int coin in coins)
            {
                if (coin <= amount && counts[amount - coin] != int.MaxValue &&
                    counts[amount - coin] + 1 < counts[amount])
                {
                    counts[amount] = counts[amount - coin] + 1;
                    lastCoin[amount] = coin;
                }
            }
        }

        if (counts[target] == int.MaxValue)
            throw new ArgumentException("The target cannot be formed from the available coins.", nameof(target));

        var result = new int[counts[target]];
        int remaining = target;
        for (int index = 0; index < result.Length; index++)
        {
            result[index] = lastCoin[remaining];
            remaining -= result[index];
        }

        Array.Sort(result);
        return result;
    }
}
