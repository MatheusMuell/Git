using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadComEscolhaDeQuantidade
{
    class Program
    {
        static List<ListaThread> listaThreadLoad = new List<ListaThread>();
        static long indice = 0;

        static void Main(string[] args)
        {
            Thread threadCarregar = new Thread(IncrementIndex);
            threadCarregar.Start();

            Thread threadCarregar1 = new Thread(IncrementIndex);
            threadCarregar1.Start();

            Thread threadCarregar2 = new Thread(IncrementIndex);
            threadCarregar2.Start();

            var iniciou = DateTime.Now;

            while (indice < 10000000000000000) { }

            var tempoTotal = DateTime.Now - iniciou;

            Console.WriteLine($"Tempo para a execução: {tempoTotal}");
            Console.ReadKey();// 00:00:00.0003255
        }

        public static void IncrementIndex()
        {
            while (indice < 10000000000000000)
            {
                indice++;
            }
        }

        public static void IncrementIndex1()
        {
            while (indice < 10000000000000000)
            {
                indice++;
            }
        }

        public static void CarregaLista()
        {
            for (long i = 0; i < 10000000000000000; i++)
            {
                try
                {
                    listaThreadLoad.Add(new ListaThread()
                    {
                        Numero = indice++
                    });
                }
                catch (Exception ex)
                {
                    //
                }
            }
        }
    }

    public class ListaThread
    {
        /// <summary>
        /// Número que define a ordem de criação.
        /// </summary>
        public long Numero { get; set; } = 0;

        /// <summary>
        /// Identificador booleano que mostra se foi atualizado;
        /// </summary>
        public bool Atualizado { get; set; } = false;
    }
}
