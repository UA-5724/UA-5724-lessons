namespace ConsoleApp1
{

    internal class Program
    {
        static void Main1(string[] args)
        {

            //int x = int.Parse(Console.ReadLine());
            //if (x > 5)
            //{
            //    Console.WriteLine("x is greater than 5");
            //}
            //else
            //{
            //    Console.WriteLine("x is not greater than 5");
            //}

            //int temperature = int.Parse(Console.ReadLine());
            //if (temperature < 10)
            //{
            //    Console.WriteLine("It’s too cold");
            //}
            //else
            //{
            //    if (temperature > 10)
            //    {
            //        Console.WriteLine("It’s too hot");
            //    }
            //    else
            //    {
            //        Console.WriteLine("It’s Ok");
            //    }
            //}

            //int age = int.Parse(Console.ReadLine());
            //if (age == 0)
            //{
            //    Console.WriteLine("You are not born yet");
            //}
            //else if (age < 6)
            //{
            //    Console.WriteLine("You are a baby");
            //}
            //else if (age < 18)
            //{
            //    Console.WriteLine("You are a minor");
            //}
            //else if (age >= 18 && age < 65)
            //{
            //    Console.WriteLine("You are an adult");
            //}
            //else
            //{
            //    Console.WriteLine("You are a senior");
            //}

            //if (age == 0)
            //{
            //    Console.WriteLine("You are not born yet");
            //}
            //else
            //{
            //    if (age < 6)
            //    {
            //        Console.WriteLine("You are a baby");
            //    }
            //    else
            //    {
            //        if (age < 18)
            //        {
            //            Console.WriteLine("You are a minor");
            //        }
            //        else
            //        {
            //            if (age >= 18 && age < 65)
            //            {
            //                Console.WriteLine("You are an adult");
            //            }
            //            else
            //            {
            //                Console.WriteLine("You are a senior");
            //            }
            //        }
            //    }
            //}

            //int age = int.Parse(Console.ReadLine());
            //if (age == 0)
            //{
            //    Console.WriteLine("You are not born yet");
            //}

            //if (age < 6)
            //{
            //    Console.WriteLine("You are a baby");
            //}

            //if (age < 18)
            //{
            //    Console.WriteLine("You are a minor");
            //}

            //if (age >= 18 && age < 65)
            //{
            //    Console.WriteLine("You are an adult");
            //}
            //else
            //{
            //    Console.WriteLine("You are a senior");
            //}
            //bool isRaining = true;
            //if (isRaining)
            //{
            //    Console.WriteLine("It is raining");
            //}



            Console.WriteLine("Do you enjoy C# ? (yes/no/maybe)");
            string input = Console.ReadLine();
            switch (input.ToLower())
            {
                case "yes":
                    Console.WriteLine("Awesome!");
                    break;
                case "maybe":
                    Console.WriteLine("Great!");
                    break;
                case "no":
                    Console.WriteLine("Too bad!");
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
            //if (input.ToLower() == "yes")
            //{
            //    Console.WriteLine("Awesome!");
            //}
            //else if (input.ToLower() == "maybe")
            //{
            //    Console.WriteLine("Great!");
            //}
            //else if (input.ToLower() == "no")
            //{
            //    Console.WriteLine("Too bad!");
            //}

            Console.WriteLine("End of program");
        }
    }
}







