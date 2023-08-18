using System;
using System.Numerics;

public class Program
{
    private const int ERROR_SUCCESS = 0;
    private const int ERROR_BAD_ARGUMENTS = 0xA0;
    private const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
    private const int ERROR_INVALID_COMMAND_LINE = 0x667;

    public async static Task<int> Main()
    {
        Console.WriteLine("Hello, World!");
        await DelayWithCallback(10000, () =>
        {
            Console.WriteLine("Completed");
        });
        Console.WriteLine("Done");
        return ERROR_BAD_ARGUMENTS;
    }

    static async Task DelayWithCallback(int millisecondsDelay, Action callback)
    {
        await Task.Delay(millisecondsDelay);
        callback?.Invoke();
    }
}