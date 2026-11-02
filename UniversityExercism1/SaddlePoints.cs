using System;
using System.Collections.Generic;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        var rowMaxima = new int[rows];
        var columnMinima = new int[columns];
        Array.Fill(rowMaxima, int.MinValue);
        Array.Fill(columnMinima, int.MaxValue);

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                rowMaxima[row] = Math.Max(rowMaxima[row], matrix[row, column]);
                columnMinima[column] = Math.Min(columnMinima[column], matrix[row, column]);
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if (matrix[row, column] == rowMaxima[row] &&
                    matrix[row, column] == columnMinima[column])
                    yield return (row + 1, column + 1);
            }
        }
    }
}
