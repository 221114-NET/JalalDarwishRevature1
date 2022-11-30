namespace reflectionDemo;

using System.Reflection;
using ERSModelsLayer;

class Program
{
    //private string pvString;
    public int refTest = 0;
    public string? refString {get; set;} = "Banana";
    private string? pvString {get; set;} = "no access";

    public void ThisIsATestMethod(int x)
    {
        double dY = 2.0;
        int y = 2;
        dY+=dY;
        y+=y;
        //This is a comment
        System.Console.WriteLine(x+y);
        
    }

    public void PrintPrivateString()
    {
        System.Console.WriteLine(pvString);
    }

    static void Main(string[] args)
    {
        Employee e = new Employee();

        Program p = new Program();

        Type programType = typeof(Program);
        MemberInfo[] mbrInfo = programType.GetMembers();

        MethodInfo[] methodsInfo = programType.GetMethods();

        // foreach(var mtd in methodsInfo)
        // {
        //     System.Console.WriteLine(mtd?.GetMethodBody()?.LocalVariables);
        // }

        MethodInfo? testMethodInfo = programType.GetMethod("ThisIsATestMethod");
        object[] paramArray = {1 /*,2*/}; //If parameter count doesnt match, Parameter count mismatch error
        int paramArrayLength = testMethodInfo.GetParameters().Length;
        testMethodInfo?.Invoke(p, paramArray);
        Console.WriteLine(testMethodInfo?.GetMethodBody()?.LocalVariables[1]);
        System.Console.WriteLine(testMethodInfo?.GetParameters()[0]);
        Console.WriteLine(testMethodInfo?.ReturnType);

        // PropertyInfo privString = programType.GetProperty("pvString");
        // privString.SetValue(p, "joke's on you");
        // p.PrintPrivateString();


        // foreach(var mbr in mbrInfo)
        // {
        //     //System.Console.Write($"{mbr.Name} - ");
        //     System.Console.WriteLine($"{mbr.Name} - {mbr.DeclaringType}");

        // }

        // var assemblyP = programType.Assembly;
        // System.Console.WriteLine($"{assemblyP.GetName().FullName}");

        // var fieldsP = programType.GetFields();
        // foreach(var x in fieldsP)
        // {
        //     System.Console.WriteLine($"{x.Attributes}");
        // }


    }
}
