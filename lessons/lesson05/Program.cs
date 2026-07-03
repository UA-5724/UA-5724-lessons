namespace ConsoleApp1
{

    public class User
    {
        public static int userCount = 0;
        public int age;
        private string email;
        public string Email
        {
            get
            {
                Console.WriteLine("Email getter called");
                return email;
            }
            set
            {
                Console.WriteLine($"Email setter called. Setting email to {value}");
                email = value;

            }
        }
        private string name;
        private const string city = "Abu Dhabi";
        private readonly string creationDate;

        public User()
        {
            Console.WriteLine("User default constructor called");
            this.name = "Default Name";
            this.age = 0;
            this.Email = "default@example.com";
        }
        public User(string name, int age, string email)
        {
            Console.WriteLine("User constructor called");
            this.name = name;
            this.age = age;
            this.Email = email;
            this.creationDate = DateTime.Now.ToString("yyyy-MM-dd");
            userCount++;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {this.GetAge()}, Email: {email}, User Count: {User.GetUserCount()}");
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name.ToUpper();
        }
        private int GetAge()
        {
            return age;
        }
        public static int GetUserCount()
        {
            return userCount;
        }
        public static void SetUserCount(int count)
        {
            userCount = count;
        }

        public void Update(string email)
        {
            this.Email = email;
        }

        public void Update(string email, int age)
        {
            this.Email = email;
            this.age = age;
        }
        public void Update(string email, int age, string name)
        {
            this.Email = email;
            this.age = age;
            this.name = name;
        }
        public static User operator +(User user1, User user2)
        {
            return new User(user1.name + " & " + user2.name, (user1.age + user2.age) / 2, user1.Email);
        }
        public static User operator -(User user1)
        {
            return new User(user1.name + " - ", user1.age - 1, user1.Email);
        }

        public override string ToString()
        {
            return $"Name: {name}, Age: {age}, Email: {email}";
        }
        public static bool operator ==(User user1, User user2)
        {
            return user1.name == user2.name && user1.age == user2.age && user1.Email == user2.Email;
        }
        public static bool operator !=(User user1, User user2)
        {
            return !(user1 == user2);
        }
        public bool customEquals(User user)
        {
            return this.GetHashCode() == user.GetHashCode();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            User user1;
            Console.WriteLine("User count before creating instances: " + User.GetUserCount());
            user1 = new User("John Doe", 30, "john.doe@example.com");
            Console.WriteLine("User count before creating instances: " + User.GetUserCount());
            User user2 = new User("Jane Smith", 25, "jane.smith@example.com");
            Console.WriteLine("User count before creating instances: " + User.GetUserCount());
            user1.DisplayInfo();
            user2.DisplayInfo();
            Console.WriteLine("User count before creating instances: " + User.GetUserCount());
            user1.SetName("Johnathan Doe");
            User.SetUserCount(50);
            user1.DisplayInfo();
            user2.DisplayInfo();
            user1.age = 90;
            user1.DisplayInfo();
            //user1.name = "New Name"; // This line will cause a compilation error because 'name' is private
            user1.DisplayInfo();
            user1.Email = "johnathan.doe@example.com";
            Console.WriteLine("user email: " + user1.Email);
            user1.DisplayInfo();

            User user3 = new User();
            user3.DisplayInfo();
            user3.Update("user3@example.com");
            user3.DisplayInfo();
            user3.Update("user31@example.com", 25);
            user3.DisplayInfo();
            user3.Update("user311@example.com", 95, "User Three");
            user3.DisplayInfo();
            User user4 = user1 + user2; // This line will cause a compilation error because the '+' operator is not defined for User class
            user4.DisplayInfo();
            User user5 = -user4; // This line will cause a compilation error because the '-' operator is not defined for User class
            user5.DisplayInfo();

            Console.WriteLine(user5); // This line will cause a compilation error because the 'ToString' method is not overridden in User class
            User user61 = new User("User Six One", 40, "user61@example.com");
            User user62 = new User("User Six One", 40, "user61@example.com");
            Console.WriteLine("user61 == user62: " + (user61 == user62)); // This line will cause a compilation error because the '==' operator is not defined for User class
            Console.WriteLine("user61 is equal to user62: " + user61.Equals(user62)); // This line will cause a compilation error because the '!=' operator is not defined for User class

            User user63 = user61;
            Console.WriteLine("user61 == user63: " + (user61 == user63));
            Console.WriteLine("user61 is equal to user63: " + user61.Equals(user63));

        }
    }
}







