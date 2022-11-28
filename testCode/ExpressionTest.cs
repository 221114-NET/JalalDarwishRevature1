using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testCode
{
    public class ExpressionTest
    {
        private int etNum;
        public ExpressionTest(int num = 0) => etNum = num;

        public int ETNumber
        {
            get => etNum;
            set => etNum = value;
        }

        //Overloaded addition operator to add ExpressionTest etNum
        public static ExpressionTest operator +(ExpressionTest a, ExpressionTest b) => new ExpressionTest(a.ETNumber + b.ETNumber);

        ~ExpressionTest() => Console.WriteLine("I hate the garbage collector");
    }

    public class ForceGarbage
    {
        public static void ForceGC()
        {
            ExpressionTest? pleaseWork = new ExpressionTest(1);
            pleaseWork = new ExpressionTest(2);
            pleaseWork = null;
        }
    }
}