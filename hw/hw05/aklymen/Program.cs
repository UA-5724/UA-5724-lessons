namespace hw05
{
    class Program
    {
        static void Main()
        {
            // 1. Class Car
            Console.WriteLine("CAR");

            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();

            Console.WriteLine("Enter data for Car 1:");
            car1.Input();

            Console.WriteLine();
            Console.WriteLine("Enter data for Car 2:");
            car2.Input();

            Console.WriteLine();
            Console.WriteLine("Enter data for Car 3:");
            car3.Input();

            Console.WriteLine();
            Console.WriteLine("Cars:");

            car1.Print();
            car2.Print();
            car3.Print();


            // 2. Decrease price by 10%
            car1.ChangePrice(-10);
            car2.ChangePrice(-10);
            car3.ChangePrice(-10);

            Console.WriteLine();
            Console.WriteLine("Cars after 10% price decrease:");

            car1.Print();
            car2.Print();
            car3.Print();


            // 3. Repaint Car
            Console.WriteLine();

            Console.Write("Enter new color: ");
            string newColor = Console.ReadLine() ?? "";

            if (car1.Color.ToLower() == "white")
            {
                car1.Color = newColor;
            }

            if (car2.Color.ToLower() == "white")
            {
                car2.Color = newColor;
            }

            if (car3.Color.ToLower() == "white")
            {
                car3.Color = newColor;
            }

            Console.WriteLine();
            Console.WriteLine("Cars after repaint:");

            car1.Print();
            car2.Print();
            car3.Print();


            // 4. Compare Cars
            Console.WriteLine();
            Console.WriteLine($"Car 1 == Car 2: {car1 == car2}");
            Console.WriteLine($"Car 1 == Car 3: {car1 == car3}");

            Console.WriteLine();


            // 5. Class Person
            Console.WriteLine("PERSON");

            Person[] persons = new Person[6];

            for (int index = 0; index < 6; index++)
            {
                persons[index] = new Person();

                Console.WriteLine();
                Console.WriteLine($"Enter data for Person {index + 1}:");
                persons[index].Input();
            }


            // 6. Output Name and Age
            Console.WriteLine();
            Console.WriteLine("Persons:");

            for (int index = 0; index < 6; index++)
            {
                Console.WriteLine(
                    $"Name: {persons[index].Name}, Age: {persons[index].Age()}");
            }


            // 7. Change name if Age < 16
            for (int index = 0; index < 6; index++)
            {
                if (persons[index].Age() < 16)
                {
                    persons[index].ChangeName();
                }
            }


            // 8. Output updated information
            Console.WriteLine();
            Console.WriteLine("Updated persons:");

            for (int index = 0; index < 6; index++)
            {
                persons[index].Output();
            }


            // 9. Find persons with same names
            Console.WriteLine();
            Console.WriteLine("Persons with same names:");

            bool foundSameName = false;

            for (int i = 0; i < 6; i++)
            {
                for (int j = i + 1; j < 6; j++)
                {
                    if (persons[i] == persons[j])
                    {
                        Console.WriteLine(
                            $"{persons[i].Name}: Person {i + 1} and Person {j + 1}");

                        foundSameName = true;
                    }
                }
            }

            if (!foundSameName)
            {
                Console.WriteLine("No persons with same names.");
            }
        }
    }
}