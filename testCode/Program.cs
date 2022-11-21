namespace testCode;
class Program
{
    static void Main(string[] args)
    {
        string emptyTest = "";
        TestStuff.EmptyTest(emptyTest);
    }
}

class TestStuff
{
    public static void EmptyTest(string s)
    {
        Console.WriteLine(s);
    }
}