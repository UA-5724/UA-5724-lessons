namespace HW10
{
    public class Accountancy
    {
        public void PayingFellowship(int mark)
        {
            if (mark >= 4)
            {
                Console.WriteLine("Accountancy: the mark " + mark + " keeps the scholarship");
            }
            else
            {
                Console.WriteLine("Accountancy: the mark " + mark + " leaves the student without the scholarship");
            }
        }
    }
}
