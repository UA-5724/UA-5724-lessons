using System.Text.Json;

namespace hw10.Task4
{
    namespace hw10.Task4
    {
        class Program
        {
            static void Main()
            {

                Student studentForJson = new Student("Anna");

                studentForJson.AddMark(5);
                studentForJson.AddMark(5);
                studentForJson.AddMark(4);

                // Serialize object

                string json = JsonSerializer.Serialize(
                    studentForJson,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                File.WriteAllText("student.json", json);

                Console.WriteLine("Student was serialized to student.json.");

                Console.WriteLine();
                Console.WriteLine("JSON:");
                Console.WriteLine(json);


                // Deserialize object

                string jsonFromFile = File.ReadAllText("student.json");

                Student newStudent = JsonSerializer.Deserialize<Student>(jsonFromFile);

                Console.WriteLine();
                Console.WriteLine("Deserialized student:");

                Console.WriteLine($"Name: {newStudent.Name}");

                Console.WriteLine("Marks:");

                foreach (int mark in newStudent.Marks)
                {
                    Console.Write(mark + " ");
                }

                Console.WriteLine();
            }
        }
    }
}