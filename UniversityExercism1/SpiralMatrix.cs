public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        var matrix = new int[size, size];
        int value = 1;

        for (int start = 0; start < (size + 1) / 2; start++)
        {
            int end = size - start - 1;

            for (int column = start; column <= end; column++)
                matrix[start, column] = value++;

            for (int row = start + 1; row <= end; row++)
                matrix[row, end] = value++;

            for (int column = end - 1; column >= start; column--)
                matrix[end, column] = value++;

            for (int row = end - 1; row > start; row--)
                matrix[row, start] = value++;
        }

        return matrix;
    }
}
