using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Password
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string letterAlph = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        string numberAlph = "0123456789";
        string specialSymblAlph = "!@#$%^&*()_+-<>?:;,./|";
        Random random = new Random();
        
        
        private string RandPasswor(string _allAlph,int lenght)
        {
            StringBuilder pass = new StringBuilder(lenght);
            for(int i = 0; i < lenght; i++) 
            {
                pass.Append(_allAlph[random.Next(_allAlph.Length)]);
            }
            return pass.ToString();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            int lenghtPass;
            string password = "";
            string allAlph = "";
            PasswordTextBox.Clear();
            if (lenghtTextBox.Text != null && lenghtTextBox.Text != string.Empty) 
            {
                lenghtPass = Convert.ToInt32(lenghtTextBox.Text);
                if (lettersCheckBox.IsChecked ?? false) 
                { 
                    allAlph += letterAlph; 
                }
                if(numbersCheckBox.IsChecked ?? false)
                {
                    allAlph += numberAlph;
                }
                if(specialSymbolsCheckBox.IsChecked ?? false) 
                { 
                    allAlph += specialSymblAlph; 
                }


                if(allAlph != null && allAlph != string.Empty)
                {
                    password = RandPasswor(allAlph,lenghtPass);
                    PasswordTextBox.Text = password;
                }
                else if (specialSymbolsCheckBox.IsChecked == false ||
                    lettersCheckBox.IsChecked == false ||
                    numbersCheckBox.IsChecked == false)
                {
                    MessageBox.Show("Поле с символами пустое", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Поле с текстом пустое", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(PasswordTextBox.Text);
        }
    }
}
