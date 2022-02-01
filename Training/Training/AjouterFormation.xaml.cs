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
    /// Logique d'interaction pour AjouterFormation.xaml
    /// </summary>
    public partial class AjouterFormation : Window
    {
        private const string TXT_MSG_FORMATION_INVALIDE = "Veuilles saisir le nom de la Formation";
        private const string TXT_MSG_DATE_INVALIDE1 = "Date début et date fin ne devront etre identiques";
        private const string TXT_MSG_DATE_INVALIDE2 = "Date Fin  ne devrait etre inferieur de Date Debut";
        private const string TXT_MSG_CONFIR_ADD = "Formation créé avec succès!";

        
        Gestion gest;

        public AjouterFormation()
        {
            InitializeComponent();
            gest = new Gestion();
            CbmType.DataContext = Singleton.Instance.myBDD.TypeFormations.ToList();
            CbmEnseignant.DataContext = Singleton.Instance.myBDD.Enseignants.ToList();
            dpDebut.SelectedDate = DateTime.Today;
            dpFin.SelectedDate = DateTime.Today;

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


        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFormation.Text))
            { afficherMsgError(TXT_MSG_FORMATION_INVALIDE); txtFormation.Focus(); return; }

            if (dpDebut.SelectedDate.Value == dpFin.SelectedDate.Value) 
            { afficherMsgError(TXT_MSG_DATE_INVALIDE1); txtFormation.Focus(); return; }

            if (dpDebut.SelectedDate.Value > dpFin.SelectedDate.Value)
            { afficherMsgError(TXT_MSG_DATE_INVALIDE2); txtFormation.Focus(); return; }

            string result = gest.AjoutFormation(txtFormation.Text, dpDebut.SelectedDate, dpFin.SelectedDate, ((Enseignant)CbmEnseignant.SelectedItem).IdFormateur, ((TypeFormation)CbmType.SelectedItem).IdType);

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
