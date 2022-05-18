using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Human
    {
        private string Name { get; set; }
        private int Age { get; set; }
        private bool Sex { get; set; }

        public Human()
        {
            Name = "defaultName";
            Age = 0;
            Sex = true;
        }

        public Human(string name, int age, bool sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        }

        public virtual string GetInfo()
        {
            return "Имя - " + Name + ", Возраст - " + Age + ", Пол - " + (Sex ? "Мужик" : "Тёлочка");
        }

    }


    class Homeless : Human
    {
        public string AlcoholType { get; set; }

        public Homeless(string name, int age, bool sex, string alcoholType) : base(name, age, sex)
        {
            AlcoholType = alcoholType;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", Выпивает - " + AlcoholType;

        }
    }

    class Somelie : Homeless
    {
        public string Salary { get; set; }

        public Somelie(string name, int age, bool sex, string alcoholType, string salary) : base(name, age, sex, alcoholType)
        {
            Salary = salary;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", Зарплата - " + Salary;
        }
    }

    class OutputPrinter
    {
        int user = 0;

        public void PrintInfo(Human person)
        {
            Console.WriteLine($"Пользователь {++user}:{person.GetInfo()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OutputPrinter printer1 = new OutputPrinter();

            List<Human> users = new List<Human>();
            users.Add(new Human("Натасяо", 29, false));
            users.Add(new Human("Вовка", 29, true));
            users.Add(new Human("Максимка", 28, true));
            users.Add(new Homeless("Петрович", 61, true, "Боярышник"));
            users.Add(new Somelie("Альберто", 36, true, "Сагрантино ди Монтефалько", "10 000 Euro"));

             
            foreach(var user in users)
            {
                printer1.PrintInfo(user);
            }

            Console.ReadKey();
        }
    }
}

