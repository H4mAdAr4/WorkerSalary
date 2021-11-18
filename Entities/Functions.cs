using System;
using System.Globalization;

namespace WorkerSalary.Entities {
    class Functions {
        public static void Menu(Worker worker) {
            Console.Clear();
            Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Welcome user! What do you wish to do?:");
            Console.WriteLine("1 - Add more contracts");
            Console.WriteLine("2 - Remove contracts");
            Console.WriteLine("3 - Calculate income");
            Console.WriteLine("4 - Exit system");
            int index = int.Parse(Console.ReadLine());

            switch (index) {
                case 1:
                    Add(worker);
                    Console.Clear();
                    Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Thank you user! What do you wish to do?:");
                    Console.WriteLine("1 - Do another operation");
                    Console.WriteLine("2 - Exit system");
                    index = int.Parse(Console.ReadLine());
                    if (index == 1) {
                        Menu(worker);
                    } else {
                        Environment.Exit(0);
                    }
                    break;
                case 2:
                    Remove(worker);
                    Console.Clear();
                    Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Thank you user! What do you wish to do?:");
                    Console.WriteLine("1 - Do another operation");
                    Console.WriteLine("2 - Exit system");
                    index = int.Parse(Console.ReadLine());
                    if (index == 1) {
                        Menu(worker);
                    } else {
                        Environment.Exit(0);
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
                    Console.WriteLine("--------------------------");
                    Console.Write("Please specify the year: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("Please specify the month: ");
                    int month = int.Parse(Console.ReadLine());
                    double income = worker.Income(year, month);
                    Console.Clear();
                    Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Name: {worker.Name}");
                    Console.WriteLine($"Department: {worker.Departament}");
                    Console.WriteLine($"Income for {month}/{year}: $" + income.ToString("F2", CultureInfo.InvariantCulture));
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Thank you user! What do you wish to do?:");
                    Console.WriteLine("1 - Do another operation");
                    Console.WriteLine("2 - Exit system");
                    index = int.Parse(Console.ReadLine());
                    if (index == 1) {
                        Menu(worker);
                    } else {
                        Environment.Exit(0);
                    }
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
        public static void Add(Worker worker) {
            Console.Clear();
            Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
            Console.WriteLine("--------------------------");
            Console.Write("How many contracts do you wish to add? ");
            int contNum = int.Parse(Console.ReadLine());
            int i = 0;
            while (i < contNum) {
                Console.Clear();
                Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Enter #{i + 1} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
                i++;
            }
        }
        public static void Remove(Worker worker) {
            Console.Clear();
            Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
            Console.WriteLine("--------------------------");
            Console.Write("How many contracts do you wish to Remove? ");
            int contNum = int.Parse(Console.ReadLine());
            int i = 0;
            while (i < contNum) {
                Console.Clear();
                Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Enter #{i + 1} contract date:");
                DateTime date = DateTime.Parse(Console.ReadLine());
                bool aux = worker.RemoveContract(date);
                if (aux == true) {
                    i++;
                } else {
                    throw new InvalidOperationException("Invalid Operation!");
                }
            }
        }
    }
}