using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComposantProceeding;
using ComposantArticle;

namespace ComposantBD
{
    public class articleBD : IProceeding
    {
        DataClasses1DataContext db;
        
        //-----------------------------------------------------------------------------
        public void init()
        {
            db = new DataClasses1DataContext();
        }
        //-----------------------------------------------------------------------------
        public List<article> getAllCatalogue()// pour afficher tous les articles BD
        {
            init();
            List<article> L = new List<article>(); //cette liste dynamique contiendra les tuples de la table q'on transmetra au demandeur
            article art;
            var q = from c in db.GetTable<Articles>() select c;

            //remplissage de la liste dynamique
            foreach (var copt in q)
            {
                art = new article(copt.Code_article, copt.Titre_article, copt.Type_article, (int)copt.Frais_soumission, (int)copt.Nombre_page);
                L.Add(art); 
            }
            return L;
        }
        //-----------------------------------------------------------------------------------------------------------------------

        public void remove(int codeart) // pour supprimer un article
        {
            db = new DataClasses1DataContext();
            try
            {
                var tt1 = (from c2 in db.GetTable<Articles>() where c2.Code_article == codeart select c2).SingleOrDefault();
                db.Articles.DeleteOnSubmit(tt1);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                //throw;
            }
            
        }

        public void insert(article p) // pour ajouter un nouveau article
        {
            init();
            Articles art = new Articles();
            art.Code_article = p.Codearticle;
            art.Titre_article = p.Titrearticle;
            art.Type_article = p.Typearticle;
            art.Frais_soumission = p.FraisSoumission;
            art.Nombre_page = p.NombrePage;

            try
            {
                db.Articles.InsertOnSubmit(art);
                db.SubmitChanges();
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }
        public void update(article p, int rang)// pour mettre à jour un article particulier
        {
            db = new DataClasses1DataContext();

            var all = from c in db.GetTable<Articles>() where c.Code_article == p.Codearticle select c;
            foreach (var c in all)
            {
                c.Code_article = p.Codearticle;
                if (rang == 1)
                {
                    c.Titre_article = p.Titrearticle;
                }
                if(rang == 2)
                {
                    c.Titre_article = p.Titrearticle;
                    c.Type_article = p.Typearticle;
                }
                if (rang == 3)
                {
                    c.Titre_article = p.Titrearticle;
                    c.Type_article = p.Typearticle;
                    c.Frais_soumission = p.FraisSoumission;
                }
                if (rang == 4)
                {
                    c.Titre_article = p.Titrearticle;
                    c.Type_article = p.Typearticle;
                    c.Frais_soumission = p.FraisSoumission;
                    c.Nombre_page = p.NombrePage;
                }
                
                
            }

            db.SubmitChanges();
        }
        public article lookup(int p)// pour rechercher un ou plusieurs articles.
        {
            db = new DataClasses1DataContext();
            article art = new article(); 
            var all = from c in db.GetTable<Articles>() where c.Code_article == p select c;
            foreach (var c in all)
            {
                art = new article(c.Code_article, c.Titre_article, c.Type_article, (int)c.Frais_soumission, (int)c.Nombre_page);
            }

            return art;
        }


    }
}
