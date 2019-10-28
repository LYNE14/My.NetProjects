using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComposantArticle;

namespace ComposantProceeding
{
    public interface IProceeding
    {
        List<article> getAllCatalogue();// pour afficher tous les articles BD
        void remove(int cod); // pour supprimer un article
        void insert(article p); // pour ajouter un nouveau article
        void update(article p, int rang);// pour mettre à jour un article particulier
        article lookup(int p);// pour rechercher un ou plusieurs articles.
    }
}
