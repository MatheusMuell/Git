using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static List<ParallelListTeste> listaDeitens = new List<ParallelListTeste>();
        static void Main(string[] args)
        {
            var inicioDaOperacao = DateTime.Now;
            CarregaListaParallel();
            var tempoTotal = DateTime.Now - inicioDaOperacao;

            Console.WriteLine($"Tempo total para executar a operação : {tempoTotal}");
            Console.ReadKey();
        }

        public static void CarregaListaParallel()
        {
            for (int i = 0; i < 100000; i++)
            {
                listaDeitens.Add(new ParallelListTeste()
                {
                    Numero = 1
                });
            }
        }

        public static void CarregaLista()
        {
            for (int i = 0; i < 1000; i++)
            {
                listaDeitens.Add(new ParallelListTeste()
                {
                    Numero = 1
                });
            }
        }
    }

    public class ParallelListTeste
    {
        ///<summary>
        /// Número que indica a prde, de criação deste item;
        /// </summary>

        public int Numero { get; set; } = 0;

        /// <summary>
        /// Indicador booleano que mostrase foi atualizado ou não
        /// </summary>

        public bool Atualizado { get; set; }

    }
}
