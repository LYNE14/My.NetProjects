using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComposantArticle;

namespace ComposantProceeding
{
    public class ProceedingC : IArticle
    {
        List<article> L = new List<article>();

        //implémeter la fonction qui crée un article dont la signature est déclarée au niveau de l'interface 
        //IArticle qui se trouve dans le projet "composantArticle"
        article art;
        public void creerArticle(int Code_article1, String Titre_article1, String Type_article1, int Frais_soumission1, int Nombre_page1)
        {
            art = new article(Code_article1, Titre_article1, Type_article1, Frais_soumission1, Nombre_page1);
        }
        //--------------------------------------------------------------------------------------------------------//
        //les interfaces requises:
        /*1*/
        public List<article> getAllCatalogue(IProceeding proc)
        {
            L = proc.getAllCatalogue();
            return L;
        }
        public void insert(IProceeding ip)
        {
            ip.insert(art);
        }
        public void remove(int cod, IProceeding ip) // pour supprimer un article
        {
            ip.remove(cod);
        }
        public void update(article p, IProceeding ip,int rang)// pour mettre à jour un article particulier
        {
            ip.update(p,rang);
        }
        public article lookup(int p, IProceeding ip)// pour rechercher un ou plusieurs articles.
        {
            art = new article();
            art = ip.lookup(p);
            return art;
        }
        
    }
}
