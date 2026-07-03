using System;

namespace hw3
{
    enum TestCaseStatus
    {
        Pass,
        Fail,
        Blocked,
        WP,
        Unexecuted
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TestCaseStatus test1Status = TestCaseStatus.Pass;

            Console.WriteLine("Test status: " + test1Status);

            Console.ReadKey();
        }
    }
}