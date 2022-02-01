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
    /// Logique d'interaction pour AjouterTypeFormation.xaml
    /// </summary>
    public partial class AjouterTypeFormation : Window
    {
        private const string TXT_MSG_DATA_Empty = "Veuilles saisir le domaine de formation ";
        private const string TXT_MSG_CONFIR_ADD = "Formation créé avec succès!";
        Gestion gest;
        List<TypeFormation> types;

        public AjouterTypeFormation()
        {
            InitializeComponent();
            gest = new Gestion();
        }

        private void btnAjout_Click(object sender, RoutedEventArgs e)
        {
                if (string.IsNullOrEmpty(txtFormation.Text))

                { afficherMsgError(TXT_MSG_DATA_Empty); return; }

                string result = gest.AjoutTypeFormation(txtFormation.Text);

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

        private void txtFormation_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAfficher_Click(object sender, RoutedEventArgs e)
        {
            types = Singleton.Instance.myBDD.TypeFormations.ToList();

            txtType.Text = gest.AfficherTypeFormation(types);
        }
    }
}
