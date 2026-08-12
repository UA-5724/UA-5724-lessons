namespace HW5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarTask();
            PersonTask();
        }

        static void CarTask()
        {
            Console.WriteLine("Task 1: Class Car");

            Car[] cars = new Car[3];
            for (int i = 0; i < cars.Length; i++)
            {
                Console.WriteLine("Car " + (i + 1) + ":");
                cars[i] = new Car();
                cars[i].Input();
            }

            Console.WriteLine();
            Console.WriteLine("Information about the cars:");
            foreach (Car car in cars)
            {
                car.Print();
            }

            foreach (Car car in cars)
            {
                car.ChangePrice(-10);
            }

            Console.WriteLine();
            Console.WriteLine("Information after the price was decreased by 10%:");
            foreach (Car car in cars)
            {
                car.Print();
            }

            Console.WriteLine();
            Console.Write("Enter a new color for the white cars: ");
            string newColor = Console.ReadLine();
            foreach (Car car in cars)
            {
                if (car.Color.ToLower() == "white")
                {
                    car.Color = newColor;
                }
            }

            Console.WriteLine("Information after the repainting:");
            foreach (Car car in cars)
            {
                car.Print();
            }

            Console.WriteLine();
            Console.WriteLine("Cars that are equal by name and price:");
            bool equalCarsFound = false;
            for (int i = 0; i < cars.Length; i++)
            {
                for (int j = i + 1; j < cars.Length; j++)
                {
                    if (cars[i] == cars[j])
                    {
                        Console.WriteLine("Car " + (i + 1) + " and car " + (j + 1) + " are equal");
                        equalCarsFound = true;
                    }
                }
            }

            if (!equalCarsFound)
            {
                Console.WriteLine("There are no equal cars");
            }

            Console.WriteLine();
        }

        static void PersonTask()
        {
            Console.WriteLine("Task 2: Class Person");

            Person[] persons = new Person[6];
            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine("Person " + (i + 1) + ":");
                persons[i] = new Person();
                persons[i].Input();
            }

            Console.WriteLine();
            Console.WriteLine("Name and age:");
            foreach (Person person in persons)
            {
                Console.WriteLine(person.Name + " - " + person.Age() + " years");
            }

            foreach (Person person in persons)
            {
                if (person.Age() < 16)
                {
                    person.ChangeName("Very Young");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Information after the names were changed:");
            foreach (Person person in persons)
            {
                person.Output();
            }

            Console.WriteLine();
            Console.WriteLine("Persons with the same names:");
            bool equalPersonsFound = false;
            for (int i = 0; i < persons.Length; i++)
            {
                for (int j = i + 1; j < persons.Length; j++)
                {
                    if (persons[i] == persons[j])
                    {
                        Console.WriteLine(persons[i].Name + ": person " + (i + 1) + " and person " + (j + 1));
                        equalPersonsFound = true;
                    }
                }
            }

            if (!equalPersonsFound)
            {
                Console.WriteLine("There are no persons with the same names");
            }
        }
    }
}
