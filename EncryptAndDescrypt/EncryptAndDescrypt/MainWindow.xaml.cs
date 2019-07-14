using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EncryptAndDescrypt
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtInformacaoParaEsconder.Text)
                && !String.IsNullOrEmpty(txtSenhaParaPodeEsconder.Text))
            {
                txtConteudoJaEscondido.Text = Encrypt.Criptografar(txtInformacaoParaEsconder.Text, txtSenhaParaPodeEsconder.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        public static class Encrypt
        {
            private const string initVector = "asdfadgher";
            private const int keySize = 256;

            public static string Criptografar(string pTextoEsconder, string pSenha)
            {
                byte[] iniciandoVetorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] textoPlanoBytes = Encoding.UTF8.GetBytes(pTextoEsconder);

                PasswordDeriveBytes password = new PasswordDeriveBytes(pSenha,null);
                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symetrycKey = new RijndaelManaged();
                symetrycKey.Mode = CipherMode.CBC;

                ICryptoTransform encrypto = symetrycKey.CreateEncryptor(keyBytes, iniciandoVetorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypto, CryptoStreamMode.Write);
                cryptoStream.Write(textoPlanoBytes, 0, textoPlanoBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] textoEmMemoria = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();

                return Convert.ToBase64String(textoEmMemoria);
            }

            public static string Descriptografar(string pTextoEscondido, string pSenha)
            {
                byte[] iniciandoVetorBytes = Encoding.UTF8.GetBytes(initVector);
                byte[] textoPlanoBytes = Convert.FromBase64String(pTextoEscondido);//Encoding.UTF8.GetBytes(pTextoEsconder);

                PasswordDeriveBytes password = new PasswordDeriveBytes(pSenha, null);
                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symetrycKey = new RijndaelManaged();
                symetrycKey.Mode = CipherMode.CBC;

                ICryptoTransform encrypto = symetrycKey.CreateDecryptor(keyBytes, iniciandoVetorBytes);
                MemoryStream memoryStream = new MemoryStream(textoPlanoBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encrypto, CryptoStreamMode.Read);
                byte[] textoDescriptografado = new byte[textoPlanoBytes.Length];
                int decryptCount = cryptoStream.Read(textoDescriptografado, 0, textoDescriptografado.Length);
                cryptoStream.FlushFinalBlock();
                memoryStream.Close();
                cryptoStream.Close();

                return Encoding.UTF8.GetString(textoDescriptografado, 0, decryptCount);
            }
        }
    }
}
