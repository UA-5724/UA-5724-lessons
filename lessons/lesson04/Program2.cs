namespace ConsoleApp1
{

    internal class Program2
    {
        static void Main(string[] args)
        {

            //int a = 10;
            //while (a > 0)
            //{   
            //    int t = a*10;
            //    Console.WriteLine("{0}, {1}", a, t);
            //    a--;
            //}
            ////Console.WriteLine(t); // This line will cause an error because t is not accessible outside the while loop
            //do
            //{
            //    Console.WriteLine(a);
            //    a++;
            //} while (a <= 10);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("Outer loop: {0}", i);
            //    for (int j = 0; j < i; j++)
            //    {
            //        Console.Write("\t{0}", j);
            //    }
            //    Console.WriteLine();
            //}
            //int sum = 0;
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine("Even: {0}", i);
            //        continue; // Skip the rest of the loop body and move to the next iteration
            //    }

            //    sum += i;
            //    Console.WriteLine("sum: {0}", i);
            //}
            //Console.WriteLine("Total sum: {0}", sum);

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "exit")
            //    {
            //        break; // Exit the loop if the user types "exit"
            //    }
            //    Console.WriteLine("You entered: {0}", input);

            //}
            //int[] nums5 = { 1, 2, 3, 5, 6, 7, 8, 9, 10 };
            //for (int i = 0; i < nums5.Length; i++)
            //{
            //    Console.WriteLine("nums5[{0}] = {1}", i, nums5[i]);
            //}

            int[,] matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            Console.WriteLine("Matrix:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)

                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Matrix2:");
            int n = 5, m = 6;
            int[,] matrix2 = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix2[i, j] = i * j;
                }
            }

            for (int i = 0; i < matrix2.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)

                {
                    Console.Write("{0} ", matrix2[i, j]);
                }
                Console.WriteLine();
            }

            foreach (int value in matrix2)
            {
                Console.Write("{0} ", value);
                //value++; // This will not affect the actual matrix2 values, as 'value' is a copy of the element
            }
            Console.WriteLine("End of program");
        }
    }
}







