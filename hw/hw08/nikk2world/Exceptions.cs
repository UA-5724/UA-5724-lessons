// Custom exceptions used in the homework

// Thrown by DivDouble() when the divisor is zero (Task 2)
class DivisionByZeroException : Exception
{
    public DivisionByZeroException(string message) : base(message)
    {
    }
}

// Thrown by ReadNumber() when the entered text is not an integer (Task 3)
class NotANumberException : Exception
{
    public NotANumberException(string input)
        : base($"\"{input}\" is not an integer number.")
    {
    }
}

// Thrown by ReadNumber() when the number is outside [start...end] (Task 3)
class NumberOutOfRangeException : Exception
{
    public NumberOutOfRangeException(int number, int start, int end)
        : base($"Number {number} is out of range [{start}...{end}].")
    {
    }
}
