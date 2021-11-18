using System;
using System.Globalization;
using WorkerSalary.Entities;
using WorkerSalary.Entities.Enums;

namespace WorkerSalary {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("EMPLOYER MANAGEMENT SYSTEM");
            Console.WriteLine("--------------------------");
            Console.Write("Welcome user! Please state the department's name: ");
            string department = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/Midlevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Worker worker = new Worker(name, level, salary, department);

            Functions.Add(worker);
            Functions.Menu(worker);
        }
    }
}