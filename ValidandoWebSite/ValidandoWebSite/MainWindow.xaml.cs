using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ValidandoWebSite
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<ListaRequisicoes> list = new List<ListaRequisicoes>();

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var listaDeSite = txtUrl.Text.Split(',');

            foreach (var item in listaDeSite)
            {
                string url = txtUrl.Text;
                if (!String.IsNullOrEmpty(url))
                {
                    try
                    {
                        // Cria uma requisição dentro do botão, igual a um navegador faz quando digitado a URL
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        // Espera trazer os arquivos da nuvem, indicando o StatusCode(Headers) do site
                        HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(
                            request.BeginGetResponse,
                            request.EndGetResponse,
                            request) as HttpWebResponse;

                        // Adiciona na nossa lista as informações
                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = response.StatusCode.ToString()
                        });
                    }
                    catch (Exception ex)
                    {
                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = "Erro"
                        });
                    }
                }
            }
        }

        public class ListaRequisicoes
        {
            public string Url { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
        }

        // Criado timer global
        DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // seta o método que irá utilizar o timer
            timer.Tick += new EventHandler(timer_tick);
            // tempo de execução da aplicação
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            // inicia o timer
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            // limpa tarefa toda vez que entrar no método
            txtStatusReport.Clear();
            // percorre a lista de sites
            foreach (ListaRequisicoes item in list)
            {
                // apresenta as informações de forma formatada
                txtStatusReport.AppendText($"\r\nUrl: {item.Url} \r\nStatus Code: {item.Status}");
            }
        }
    }
}