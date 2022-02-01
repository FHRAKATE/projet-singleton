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
using System.Windows.Shapes;

namespace Training
{
    /// <summary>
    /// Logique d'interaction pour AjouterEnseignant.xaml
    /// </summary>
    public partial class AjouterEnseignant : Window
    {
        private const string TXT_MSG_DATA_Empty = "Veuilles saisir tous les champs ";
        private const string TXT_MSG_CONFIR_ADD = "Enseignant(e) créé avec succès!";
        Gestion gest;

        public AjouterEnseignant()
        {
            InitializeComponent();
            gest = new Gestion();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {

            if(string.IsNullOrEmpty(txtNom.Text)|| string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtVille.Text))
                
                { afficherMsgError(TXT_MSG_DATA_Empty); return; }

            string result = gest.AjoutEnseignant(txtNom.Text, txtPrenom.Text, txtVille.Text);

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show(TXT_MSG_CONFIR_ADD, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else MessageBox.Show(result);

        }

        private void afficherMsgError(string msg)
        {
            MessageBox.Show(msg, "Attention", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
