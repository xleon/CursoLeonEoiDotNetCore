using System;

namespace Console3
{
    public class Person
    {
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 1)
                    _age = 1;

                else if (value > 100)
                    _age = 100;

                else
                    _age = value;
            }
        }

        public bool EsMayorDeEdad => Age > 17;


        public int Legs { get; set; } = 2;
        public string Name { get; set; } = "Persona";
        public float Height { get; set; } = 108.5f;

        public virtual void Sing()
        {
            
            Console.WriteLine(Legs);
            Console.WriteLine("No se cantar");
        }

        public virtual void Talk()
        {
            Console.WriteLine("Hola");
        }

        public virtual void Eat()
        {
            Console.WriteLine("Pasta y carne");
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Pedro : Person
    {
        public override void Sing()
        {
            Console.WriteLine("la la la la la");
        }

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("Hola qué tal, soy Pedro");
        }

        public override void Eat()
        {
            Console.WriteLine("Manzanas y verdura");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new Pedro();
            person.Age = 15;

            Console.WriteLine(person.EsMayorDeEdad);
            Console.WriteLine(person.Age);
            Console.WriteLine(person);
            Console.WriteLine(person.Legs);
            
            Console.WriteLine(person.Height);

            person.Talk();
            person.Eat();
            person.Sing();

            Console.ReadKey(true);
        }
    }
}
