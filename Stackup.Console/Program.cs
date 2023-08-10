// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
await DelayWithCallback(10000, () =>
{
   Console.WriteLine("Completed");
});
Console.WriteLine("Done");


static async Task DelayWithCallback(int millisecondsDelay, Action callback)
{
    await Task.Delay(millisecondsDelay);
    callback?.Invoke();
}