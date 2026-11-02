using System;

public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        var result = new string[input.Length];

        for (int row = 0; row < input.Length; row++)
        {
            char[] annotatedRow = input[row].ToCharArray();

            for (int column = 0; column < annotatedRow.Length; column++)
            {
                if (input[row][column] == '*')
                    continue;

                int flowers = 0;
                for (int neighborRow = Math.Max(0, row - 1);
                     neighborRow <= Math.Min(input.Length - 1, row + 1);
                     neighborRow++)
                {
                    for (int neighborColumn = Math.Max(0, column - 1);
                         neighborColumn <= Math.Min(input[neighborRow].Length - 1, column + 1);
                         neighborColumn++)
                    {
                        if (input[neighborRow][neighborColumn] == '*')
                            flowers++;
                    }
                }

                if (flowers > 0)
                    annotatedRow[column] = (char)('0' + flowers);
            }

            result[row] = new string(annotatedRow);
        }

        return result;
    }
}
