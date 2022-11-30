namespace testCode;
class Program
{
    static void Main(string[] args)
    {
        string emptyTest = "";
        TestStuff.EmptyTest(emptyTest);


        ExpressionTest? etTest = new ExpressionTest(1);
        Console.WriteLine(etTest.ETNumber);
        ExpressionTest? plusOverloadTest = new ExpressionTest(2);
        plusOverloadTest = etTest + plusOverloadTest;
        Console.WriteLine(plusOverloadTest.ETNumber);
        // ForceGarbage.ForceGC();
        // GC.WaitForPendingFinalizers();
        // Console.ReadLine();

    }
}

class TestStuff
{
    public static void EmptyTest(string s)
    {
        Console.WriteLine(s);
    }
}