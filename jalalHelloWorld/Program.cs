namespace jalalHelloWorld;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Jalal!");
        int x = AddFunc(5);
        Console.WriteLine(x);
    }
    static int AddFunc(int o)
    {
        int x = ++o;
        return x;
    }
}
