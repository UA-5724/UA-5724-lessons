using System;

namespace hw3
{
    enum HTTPError
    {
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter HTTP error code: ");
            int code = Convert.ToInt32(Console.ReadLine());

            if (Enum.IsDefined(typeof(HTTPError), code))
            {
                HTTPError error = (HTTPError)code;
                Console.WriteLine("Error name: " + error);
            }
            else
            {
                Console.WriteLine("Unknown HTTP error code");
            }

            Console.ReadKey();
        }
    }
}