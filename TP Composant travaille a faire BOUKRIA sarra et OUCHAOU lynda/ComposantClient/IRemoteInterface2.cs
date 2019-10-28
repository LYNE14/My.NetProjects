using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComposantProceeding;
using ComposantArticle;

using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ComposantClient
{
    
    public interface IRemoteInterface2 
    {
        void getAllCatalogue();
        //BinaryFormatter getAllCatalogue();
        void remove(int cod); // pour supprimer un article
        void insert(article p); // pour ajouter un nouveau article
        void update(article p, int rang);// pour mettre à jour un article particulier
        article lookup(int p);// pour rechercher un ou plusieurs articles.
        //int Test();
    }
}
