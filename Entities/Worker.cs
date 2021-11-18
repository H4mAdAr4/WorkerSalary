using System;
using System.Collections.Generic;
using WorkerSalary.Entities.Enums;

namespace WorkerSalary.Entities {
    class Worker {
        public string Name { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; private set; }
        public string Departament { get; private set; }

        //Lista do tipo HourContract feita para guardar os contratos realizados. 'Lembrar de usar mais listas em vez de arrays (._.)'
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();

        public Worker(string name, WorkerLevel level, double baseSalary, string departament) {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(HourContract contract) {
            Contracts.Add(contract);
        }

        public bool RemoveContract(DateTime date) {
            foreach (HourContract contract in Contracts) {
                if (contract.Date.Year == date.Date.Year && contract.Date.Month == date.Date.Month && contract.Date.Day == date.Date.Day) {
                    Contracts.Remove(contract);
                    return true;
                }
            }
            return false;
        }

        public double Income(int year, int month) {
            double money = BaseSalary;
            foreach (HourContract contract in Contracts) {
                if (contract.Date.Year == year && contract.Date.Month == month) {
                    money += contract.TotalValue();
                }
            }
            return money;
        }
    }
}