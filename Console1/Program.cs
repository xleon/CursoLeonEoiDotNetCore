using System;

namespace Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            string persona = "diego";
            int edad = 25;
            int suma = 2 + 2;
            int multi = 2 * 3;
            int div = 9 / 3;

            var combinación = suma + multi + div + edad;
            
            Console.WriteLine(persona);
            Console.WriteLine(edad + edad);
            Console.WriteLine(suma);
            Console.WriteLine(multi);
            Console.WriteLine(div);
            Console.WriteLine(combinación);

            var gente = new string[] { 
                "Carolina",
                "Fran",
                "Jovanni",
                "Juan",
                "Jesus"
            };

            const string saludo = "Hola ";

            DiAlgo();

            foreach (var person in gente)
            {
                Saludar(person);
            }

            var numeros = new int[] {
                5, 6, 8, 20, 32, 54, -2, -9, 1980
            };

            // esto es un array

            for(var i = numeros.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(i + " " + numeros[i]);
            }

            Condicionales();

            Console.WriteLine(Suma(30, 20));
            Console.WriteLine(Resta(80, 20));
            Console.WriteLine(Multiplica(2, 5));
            Console.WriteLine(Divide(10, 3));

            EsMujerYMayorDeEdad("Cristina", 18);
            EsMujerYMayorDeEdad("Paco", 32);

            Console.ReadKey();
        }

        static void Saludar(string nombre)
        {
            Console.WriteLine("Hello " + nombre);
        }

        static void DiAlgo()
        {
            Console.WriteLine("algo");
        }

        static void Condicionales()
        {
            Console.WriteLine(EsMayorDeEdad(10));
            Console.WriteLine(EsMayorDeEdad(20));
            Console.WriteLine(EsMayorDeEdad(6));
        }

        static bool EsMayorDeEdad(int edad) => edad >= 18;

        static bool EsMujer(string nombre)
        {
            var resultado = false;

            if(nombre == "Carolina")
                resultado = true;
            
            else if(nombre == "Cristina")
                resultado = true;

            else if(nombre == "Ana")
                resultado = true;

            return resultado;
        }

        static bool EsMujerYMayorDeEdad(string nombre, int edad)
        {
            var resultado = EsMujer(nombre) && EsMayorDeEdad(edad);

            Console.WriteLine($"{nombre} es mujer y mayor de edad: {resultado}");
            
            return resultado;
        }

        static decimal Suma(int x, int y) => x + y;

        static decimal Resta(int x, int y) => x - y;

        static decimal Multiplica(int x, int y) => x * y;

        static decimal Divide(int x, int y) => x / y; 
    }
}
