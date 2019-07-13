using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniciandoThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(0, 5, i => 
            {
                ImprimeOCafeEstaPronto(i);
            });

            Parallel.For(0, 5, i =>
            {
                ImprimeOAlmocoEstaPronto(i);
            });

            Console.ReadKey();
        }

        public static void ImprimeOCafeEstaPronto(int numero)
        {
            Parallel.For(0, 3, i =>
            {
                Console.WriteLine($"O café está pronto {numero}:{i}");
            });
        }

        public static void ImprimeOAlmocoEstaPronto(int numero)
        {
            Parallel.For(0, 3, i =>
            {
                Console.WriteLine($"O almoço está pronto {numero}:{i}");
            });          
        }
    }
}
