using System;

namespace Console2
{
    class Program
    {
        static void Main(string[] args)
        {
            ParesImpares();
            ComprobarSwitch();
            Ternario();

            Console.ReadKey();
        }

        static void ParesImpares()
        {
            var numbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        
            foreach(var n in numbers)
            {
                if(n % 2 == 0)
                {
                    Console.WriteLine($"{n} es par");
                }
                else
                {
                    Console.WriteLine($"{n} es impar");
                }
            }
        }

        static void ComprobarSwitch()
        {
            var cantantes = new string[] {
                "Paulina",
                "Michael Jackson",
                "Bob Marley",
                "El fary",
                "Rocio Jurado"
            };

            foreach(var cantante in cantantes)
            {
                Console.WriteLine($"{cantante} mola: {Mola(cantante)}");
            }
        }

        static bool Mola(string cantante)
        {
            switch(cantante)
            {
                case "Paulina":
                    return false;

                case "Rocio Jurado":
                    return false;

                case "Bob Marley":
                    return false;

                default:
                    return true;
            }
        }

        static void Ternario()
        {
            string candidato = "Paco";
            string ganador = candidato == "Paco" ? "si" : "no";
        }
    }
}
