namespace hw10.Task3
{
    class Accountancy
    {
        public void PayingFellowship(int mark)
        {
            if (mark >= 4)
            {
                Console.WriteLine("Student gets a scholarship.");
            }
            else
            {
                Console.WriteLine("Student does not get a scholarship.");
            }
        }
    }
}