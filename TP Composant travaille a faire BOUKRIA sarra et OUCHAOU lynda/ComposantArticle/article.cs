using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComposantArticle
{
    //[DataContract] 
    [Serializable()]
    public class article
    {
      //  [DataMember]
        private int Code_article;
        //[DataMember]
        private String Titre_article;
        //[DataMember]
        private String Type_article;
        //[DataMember]
        private int Frais_soumission;
        //[DataMember]
        private int Nombre_page;

        public int Codearticle
        {
            set { Code_article = value; }
            get { return Code_article; }
        }

        public String Titrearticle
        {
            set { Titre_article = value; }
            get { return Titre_article; }
        }

        public String Typearticle
        {
            set { Type_article = value; }
            get { return Type_article; }
        }

        public int FraisSoumission
        {
            set { Frais_soumission = value; }
            get { return Frais_soumission; }
        }

        public int NombrePage
        {
            set { Nombre_page = value; }
            get { return Nombre_page; }
        }

        public article(int Code_article1, String Titre_article1, String Type_article1, int Frais_soumission1, int Nombre_page1)
        {
            this.Code_article = Code_article1;
            this.Titre_article = Titre_article1;
            this.Type_article = Type_article1;

            this.Frais_soumission = Frais_soumission1;
            this.Nombre_page = Nombre_page1;

        }

        public article() { }
    }
}
