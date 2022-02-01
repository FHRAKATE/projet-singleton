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
    /// Logique d'interaction pour ListFormation.xaml
    /// </summary>
    public partial class ListFormation : Window
    {
        public ListFormation()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var queryTrans = from c in Singleton.Instance.myBDD.Formations
                             join t in Singleton.Instance.myBDD.TypeFormations on c.IdType equals t.IdType
                             join l in Singleton.Instance.myBDD.Enseignants on c.IdFormateur equals l.IdFormateur
                             orderby c.Id descending
                             select new
                             {
                                 c.Libelle,
                                 t.type,
                                 c.DateDebut,
                                 c.DateFin,
                                 l.Nom,
                                 l.Prenom,
                             };

            dataGrid1.DataContext = queryTrans.ToList();

        }
    }
}
