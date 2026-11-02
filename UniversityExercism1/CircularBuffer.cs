using System;

public class CircularBuffer<T>
{
    private readonly T[] buffer;
    private int readIndex;
    private int writeIndex;
    private int count;

    public CircularBuffer(int capacity)
    {
        buffer = new T[capacity];
    }

    public T Read()
    {
        if (count == 0)
            throw new InvalidOperationException();

        T value = buffer[readIndex];

        readIndex = (readIndex + 1) % buffer.Length;
        count--;

        return value;
    }

    public void Write(T value)
    {
        if (count == buffer.Length)
            throw new InvalidOperationException();

        buffer[writeIndex] = value;
        writeIndex = (writeIndex + 1) % buffer.Length;
        count++;
    }

    public void Overwrite(T value)
    {
        if (count < buffer.Length)
        {
            Write(value);
            return;
        }

        buffer[writeIndex] = value;
        writeIndex = (writeIndex + 1) % buffer.Length;
        readIndex = writeIndex;
    }

    public void Clear()
    {
        Array.Clear(buffer, 0, buffer.Length);
        readIndex = 0;
        writeIndex = 0;
        count = 0;
    }
}
