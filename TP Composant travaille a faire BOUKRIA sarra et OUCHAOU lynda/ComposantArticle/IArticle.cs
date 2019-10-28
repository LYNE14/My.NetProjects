using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComposantArticle
{
    public interface IArticle
    {
        void creerArticle(int Code_article, String Titre_article, String Type_article, int Frais_soumission, int Nombre_page);
    }
}
