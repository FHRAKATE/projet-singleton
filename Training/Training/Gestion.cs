using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Gestion
    {

        public string AjoutFormation(string libelle, DateTime? dateDebut, DateTime? dateFin, int? idFormateur, int? idType)

        {
            Formation newFormation = new Formation(libelle, dateDebut, dateFin, idFormateur, idType);
            Singleton.Instance.myBDD.Formations.Add(newFormation);

            try
            {
                Singleton.Instance.myBDD.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string AjoutEnseignant(string nom, string prenom, string ville)
        { 
        
            Enseignant newEnseignant = new Enseignant(nom, prenom, ville);

            Singleton.Instance.myBDD.Enseignants.Add(newEnseignant);

            try
            {
                Singleton.Instance.myBDD.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string AjoutTypeFormation(string type)
        {

            TypeFormation newTypeForm = new TypeFormation(type);

            Singleton.Instance.myBDD.TypeFormations.Add(newTypeForm);

            try
            {
                Singleton.Instance.myBDD.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    
       public string AfficherTypeFormation(List<TypeFormation> types)
        {
            string result = "";

            //parcourir la liste des types de Formations
            foreach(TypeFormation type in types)
            {

                result += type.ToString();
            }

            return result;
        }
    }
}
