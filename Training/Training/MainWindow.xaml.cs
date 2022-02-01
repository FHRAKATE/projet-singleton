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

namespace Training
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        public MainWindow()
        {
            InitializeComponent();


        }

        private void addEnseignant_Click(object sender, RoutedEventArgs e)
        {
            AjouterEnseignant enseignant = new AjouterEnseignant();
            enseignant.ShowDialog();
        }

        private void addTypeFormation_Click(object sender, RoutedEventArgs e)
        {
            AjouterTypeFormation type = new AjouterTypeFormation();
            type.ShowDialog();
        }


        private void FormationLst_Click(object sender, RoutedEventArgs e)
        {
            ListFormation type = new ListFormation();
            type.ShowDialog();
        }

       
        private void addFormation_Click(object sender, RoutedEventArgs e)
        {
            AjouterFormation type = new AjouterFormation();
            type.ShowDialog();
        }

 
        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            string message = "Désirez-vous réellement Fermer le Guichet ? ";
            string titre = "Attention";

            MessageBoxResult result = MessageBox.Show(message, titre, MessageBoxButton.YesNo, MessageBoxImage.Information);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
