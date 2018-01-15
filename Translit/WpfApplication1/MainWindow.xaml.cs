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
using Translit;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Transliter transliter;
        LanguageIdentifier languageIdentifier;
        public MainWindow()
        {
            InitializeComponent();
            languageIdentifier = new LanguageIdentifier();
            LinearGradientBrush gradient = new LinearGradientBrush(Color.FromRgb(185, 255, 246), Color.FromRgb(102, 255, 212), 45);
            MainContainer.Background = gradient;




        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            originalValue.Text = string.Empty;
            translitValue.Text = string.Empty;
        }

        private void ToTranslitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Language language = languageIdentifier.GetLanguage(originalValue.Text);
                transliter = Transliter.GetTransliter(language);
                translitValue.Text = transliter.Translit(originalValue.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Недопустимая строка, воспользуйтесь справкой");
            }
        }

        private void Helper_Click(object sender, RoutedEventArgs e)
        {
            Help helper = new Help();
            //helper.Visibility = Visibility.Visible;
            
            helper.Show();
        }
    }
}
