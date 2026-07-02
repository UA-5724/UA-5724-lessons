namespace ConsoleApp1
{


    public interface ISmartDevice : IComparable<ISmartDevice>
    {
        string Name { get; set; }
        void TurnOn();
        void TurnOff();
    }

    public class Lamp : ISmartDevice
    {
        public string Name { get; set; }
        public string Color { get; set; } = string.Empty;
        public Lamp(string name)
        {
            Name = name;
        }
        public Lamp(string name, string color)
        {
            Name = name;
            Color = color;
        }
        public void TurnOn()
        {
            Console.WriteLine($"Lamp {this.GetHashCode()} {Name} is turned on.");
        }
        public void TurnOff()
        {
            Console.WriteLine($"Lamp {this.GetHashCode()} {Name} is turned off.");
        }

        public void ChangeColor(string color)
        {
            this.Color = color;
            Console.WriteLine($"Lamp {this.GetHashCode()} {Name} color changed to {color}.");
        }

        public override string ToString()
        {
            return $"Lamp: {Name}, Color: {Color}";
        }


        public override bool Equals(object? obj)
        {
            if (obj is Lamp otherLamp)
            {
                return this.Name == otherLamp.Name && this.Color == otherLamp.Color;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Color);
        }
        public int CompareTo(ISmartDevice? other)
        {
            if (other == null) return 1;
            return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }

    }

    public class Thermostat : ISmartDevice
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public Thermostat(string name)
        {
            Name = name;
        }
        public Thermostat(string name, double temperature)
        {
            Name = name;
            Temperature = temperature;
        }
        public void TurnOn()
        {
            Console.WriteLine($"Thermostat {this.GetHashCode()} {Name} is turned on.");
        }
        public void TurnOff()
        {
            Console.WriteLine($"Thermostat {this.GetHashCode()} {Name} is turned off.");
        }
        public void SetTemperature(double temperature)
        {
            this.Temperature = temperature;
            Console.WriteLine($"Thermostat {this.GetHashCode()} {Name} temperature set to {temperature}°C.");
        }
        public override string ToString()
        {
            return $"Thermostat: {Name}, Temperature: {Temperature}°C";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Thermostat otherThermostat)
            {
                return this.Name == otherThermostat.Name && this.Temperature == otherThermostat.Temperature;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Temperature);
        }
        public int CompareTo(ISmartDevice? other)
        {
            if (other == null) return 1;
            return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

            //Lamp lamp = new Lamp("Living Room Lamp");
            //Console.WriteLine(lamp);
            //lamp.TurnOn();
            //lamp.ChangeColor("Blue");
            //lamp.TurnOff();
            //Console.WriteLine(lamp);
            //Thermostat thermostat = new Thermostat("Hallway Thermostat");
            //Console.WriteLine(thermostat);
            //thermostat.TurnOn();
            //thermostat.SetTemperature(22.5);
            //thermostat.TurnOff();
            //Console.WriteLine(thermostat);
            //ISmartDevice smartDevice = new Lamp("Living Room Lamp");
            //smartDevice.TurnOff();
            //Lamp lamp2 = smartDevice as Lamp;
            //Console.WriteLine(lamp2);
            //lamp2.ChangeColor("Red");
            //lamp2.TurnOff();
            //Console.WriteLine(lamp2);

            ////ISmartDevice[] devices = new ISmartDevice[6];
            ////devices[0] = new Lamp("Living Room Lamp");
            ////devices[1] = new Thermostat("Hallway Thermostat");
            ////devices[2] = new Lamp("Bedroom Lamp");
            ////devices[3] = lamp;
            ////devices[4] = thermostat;
            ////devices[5] = lamp2;
            ////Console.WriteLine("\n\tDevices in the array:");
            ////foreach (var device in devices)
            ////{
            ////    Console.WriteLine(device);
            ////    device.TurnOn();
            ////    //if (device is Lamp lampDevice)
            ////    if (device is Lamp)
            ////    {
            ////        Lamp lampDevice = (Lamp)device;
            ////        lampDevice.ChangeColor("Green");
            ////    }
            ////    else if (device is Thermostat thermostatDevice)
            ////    {
            ////        thermostatDevice.SetTemperature(-20.0);
            ////    }
            ////    device.TurnOff();

            ////}


            // List

            //ArrayList arrayList = new ArrayList();
            //arrayList.Add(new Lamp("Living Room Lamp"));
            //Console.WriteLine($"Array List count: {arrayList.Count}");
            //arrayList.Add(new Thermostat("Hallway Thermostat"));
            //Console.WriteLine($"Array List count: {arrayList.Count}");
            //arrayList.Add(new Lamp("Bedroom Lamp"));
            //Console.WriteLine($"Array List count: {arrayList.Count}");

            //foreach (var device in arrayList) { Console.WriteLine(device); }
            //arrayList.RemoveAt(1);
            //Console.WriteLine($"Array List count: {arrayList.Count}");
            //arrayList.Add(10);
            //arrayList.Insert(1, new Thermostat("Kitchen Thermostat"));
            //foreach (var device in arrayList) { Console.WriteLine(device); }

            //Console.WriteLine($"Array 10 index: {arrayList.IndexOf(10)}");
            //Console.WriteLine($"Array 11 index: {arrayList.IndexOf(11)}");

            //List<ISmartDevice> smartDevices = new List<ISmartDevice>();
            //Lamp lamp1 = new Lamp("Living Room Lamp", "White");
            //smartDevices.Add(lamp1);
            //smartDevices.Add(new Thermostat("Hallway Thermostat", 22.5));
            ////smartDevices.Add(10); # This line will cause a compile-time error because 10 is not an ISmartDevice

            //Console.WriteLine($"Smart Devices List count: {smartDevices.Count}");
            //for (int i = 0; i < smartDevices.Count; i++)
            //{
            //    Console.WriteLine(smartDevices[i]);

            //}
            //Lamp lamp3 = new Lamp("Living Room Lamp", "Blue");
            //Console.WriteLine($"Smart Devices List contains lamp3: {smartDevices.Contains(lamp3)}");
            //Console.WriteLine($"Smart Devices List contains lamp1: {smartDevices.Contains(lamp1)}");
            //smartDevices.Add(lamp3);
            //Lamp lamp4 = new Lamp("Bedroom Lamp", "Green");
            //smartDevices.Add(lamp4);
            //smartDevices.Add(new Thermostat("Kitchen Thermostat", -5.0));

            //Console.WriteLine("\n\tSmart Devices List after adding more devices:");
            //foreach (var device in smartDevices)
            //{
            //    Console.WriteLine(device);
            //}
            ////smartDevices.Sort((obj1, obj2) => string.Compare(obj1.Name, obj2.Name));
            //smartDevices.Sort();
            //Console.WriteLine("\n\tSmart Devices List after sorting:");
            //foreach (var device in smartDevices)
            //{
            //    Console.WriteLine(device);
            //}

            //Dictionary<string, List<ISmartDevice>> smartDevicesDictionary = new Dictionary<string, List<ISmartDevice>>();
            //smartDevicesDictionary["Lamps"] = new List<ISmartDevice>();
            //smartDevicesDictionary["Thermostats"] = new List<ISmartDevice>();
            //for (int i = 0; i < 10; i++)
            //{

            //    int x = Random.Shared.Next(0, 2);
            //    Console.WriteLine($"Random number generated: {x}");
            //    if (x == 0)
            //    {
            //        Lamp lamp = new Lamp($"Lamp {i}", "White");
            //        Console.WriteLine($"\t {lamp}");
            //        smartDevicesDictionary["Lamps"].Add(lamp);
            //    }
            //    else
            //    {
            //        Thermostat thermostat = new Thermostat($"Thermostat {i}", 20.0);
            //        Console.WriteLine($"\t {thermostat}");
            //        smartDevicesDictionary["Thermostats"].Add(thermostat);
            //    }

            //}
            //foreach (var pair in smartDevicesDictionary)
            //{
            //    Console.WriteLine($"\n\t{pair.Key} count: {pair.Value.Count}");
            //    foreach (var device in pair.Value)
            //    {
            //        Console.WriteLine($"\t {device}");
            //    }
            //}

            Dictionary<int, int> numberDictionary = new Dictionary<int, int>();

            for (int i = 0; i < 20; i++)
            {
                int randomNumber = Random.Shared.Next(1, 6);
                Console.WriteLine($"Random number generated: {randomNumber}");
                if (numberDictionary.ContainsKey(randomNumber))
                {
                    numberDictionary[randomNumber]++;
                }
                else
                {
                    numberDictionary[randomNumber] = 1;
                }
            }
            foreach (var pair in numberDictionary)
            {
                Console.WriteLine($"Number: {pair.Key}, Count: {pair.Value}");
            }
        }
    }
}
