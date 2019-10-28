using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using ComposantClient;
using ComposantProceeding;
using ComposantArticle;
using ComposantBD;
using System.IO;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetRemoting
{

    class RemoteOperations : MarshalByRefObject, IRemoteInterface2
    {
        List<article> L;
        IProceeding proc;
        public int Test()
        {
            Console.WriteLine("lynda");
            return 2;
        }

        //--------------------------------------------------------------
        void getAllCatalogue1()
        {
            L = new List<article>();
            var t = new ProceedingC();
            L = t.getAllCatalogue(new articleBD());
        }

        public void getAllCatalogue()//pour le client
        {
            article art = new article(1,"T1","TY1",1,1);
            //Stream str = strr;

            using (Stream str = File.Open("data.bin", FileMode.Create, FileAccess.ReadWrite))
            {
                BinaryFormatter bin = new BinaryFormatter();

                Console.Write("Le client demande a consulter la base de donnée ");
                getAllCatalogue1();
                Console.WriteLine("le nombre de tuples dans la BD est : " + L.Count.ToString());

                bin.Serialize(str, L);
            }
            
            

        }
        //--------------------------------------------------------------
        public void remove(int cod) // pour supprimer un article
        {
            Console.WriteLine("le client supprime le tuple dont le code est:" + cod.ToString());
            var t = new ProceedingC();
            t.remove(cod, new articleBD());
        }
        //--------------------------------------------------------------
        public void insert(article p)// pour ajouter un nouveau article
        {
            var t = new ProceedingC();
            t.creerArticle(p.Codearticle, p.Titrearticle, p.Typearticle, p.FraisSoumission, p.NombrePage);
            t.insert(new articleBD());
        }
        //--------------------------------------------------------------
        public void update(article p,int rang)// pour mettre à jour un article particulier
        {
            var t = new ProceedingC();
            t.update(p, new articleBD(),rang);
        }
        //--------------------------------------------------------------
        public article lookup(int p)// pour rechercher un ou plusieurs articles.
        {
            article arti = new article();
            var t = new ProceedingC();
            arti = t.lookup(p,new articleBD());
            return arti;
        }
        //--------------------------------------------------------------

    }
}
