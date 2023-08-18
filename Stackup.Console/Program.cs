using System;
using System.Numerics;

public class Program
{
    private const int ERROR_SUCCESS = 0;
    private const int ERROR_BAD_ARGUMENTS = 0xA0;
    private const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
    private const int ERROR_INVALID_COMMAND_LINE = 0x667;

    public static void Main()
    {
        try
        {
            var limit = 1000000;
            for (var i = 100; i < limit; i = i + 1000)
            {
                Thread.Sleep(6000);
                Console.WriteLine($"Job in progress {i}");
            }
            Console.WriteLine("Job completed");
            Environment.ExitCode = ERROR_SUCCESS;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occurred {e.Message}"); 
            Environment.ExitCode = ERROR_BAD_ARGUMENTS;
        }
    }

    static async Task DelayWithCallback(int millisecondsDelay, Action callback)
    {
        await Task.Delay(millisecondsDelay);
        callback?.Invoke();
    }
}