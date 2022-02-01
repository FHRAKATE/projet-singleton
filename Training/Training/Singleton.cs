using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    internal class Singleton
    {
        //Instance Singleton unique
        private static Singleton instance = null;

        //myBDD object Entité Framework
        public FormationEntities myBDD = new FormationEntities();

        //Constructeur privé pour empecher les opérations "new"
        private  Singleton() { }

        //Méthode statique, Point d'accès pour lèinstance unique du singleton
        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

    }
}
