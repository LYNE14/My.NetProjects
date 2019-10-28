using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using System.IO;

using ComposantArticle;

namespace Client
{
    public partial class Form1 : MetroForm
    {
        TcpChannel channel;
        ComposantClient.IRemoteInterface2 remoteOperation;
        List<article> L;
        DataTable t;
        article art1;

        public Form1()
        {
            InitializeComponent();

            channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel);

            t = new DataTable();
            t.Columns.Add("codeart", typeof(int));
            t.Columns.Add("titreart", typeof(string));
            t.Columns.Add("typeart", typeof(string));
            t.Columns.Add("Fraisartt", typeof(int));
            t.Columns.Add("nbpageartt", typeof(int));
            metroGrid1.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            metroGrid1.AllowUserToAddRows = false;
            
            initialiser_Com();
        }

        void clear()
        {
            t = new DataTable();
            t.Columns.Add("codeart", typeof(int));
            t.Columns.Add("titreart", typeof(string));
            t.Columns.Add("typeart", typeof(string));
            t.Columns.Add("Fraisartt", typeof(int));
            t.Columns.Add("nbpageartt", typeof(int));
            metroGrid1.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            metroGrid1.AllowUserToAddRows = false;
            metroGrid1.DataSource = t;
        }


        public void initialiser_Com()
        {

            try
            {
                remoteOperation =
                    (ComposantClient.IRemoteInterface2)Activator.GetObject(
                                                                              typeof(ComposantClient.IRemoteInterface2),
                                                                              "tcp://localhost:1069/RemoteOperation");

            }
            catch { Console.WriteLine("Erreur de connexion au serveur"); }

            Console.WriteLine("si vous voullez refaire les oppérations tapez 1");
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

       /* private void metroButton1_Click(object sender, EventArgs e)
        {
            L = new List<article>();
           
            if (remoteOperation != null)
            {
                remoteOperation.getAllCatalogue();      
            }

            BinaryFormatter bin = new BinaryFormatter();
            using(Stream str = File.Open(@"C:\Users\LYNDA\Documents\Visual Studio 2013\Projects\TP Composant travaille a faire BOUKRIA sarra et OUCHAOU lynda\NetRemoting\bin\Debug\data.bin", FileMode.Open,FileAccess.ReadWrite))
            {
                L = (List<article>)bin.Deserialize(str);
                int r = L.Count();
            }   
        }*/

        public void GetAllArticle()
        {
            metroGrid1.ClearSelection();
            /**************** Récuperer les données de la table ******************************/
            L = new List<article>();
            if (remoteOperation != null)
            {
                remoteOperation.getAllCatalogue();
            }

            BinaryFormatter bin = new BinaryFormatter();
            using (Stream str = File.Open(@"C:\Users\LYNDA\Documents\Visual Studio 2013\Projects\TP Composant travaille a faire BOUKRIA sarra et OUCHAOU lynda\NetRemoting\bin\Debug\data.bin", FileMode.Open, FileAccess.ReadWrite))
            {
                L = (List<article>)bin.Deserialize(str);
                int r = L.Count();
            }
            /************************************************************************************/

            for (int i = 0; i < L.Count; i++)
            {
                t.Rows.Add(L[i].Codearticle, L[i].Titrearticle, L[i].Typearticle, L[i].FraisSoumission, L[i].NombrePage);

            }

            
            metroGrid1.DataSource = t;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            GetAllArticle();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (remoteOperation != null)
                {
                    art1 = new article(Convert.ToInt32(metroTextBox1.Text), metroTextBox2.Text, metroTextBox3.Text, Convert.ToInt32(metroTextBox4.Text), Convert.ToInt32(metroTextBox5.Text));
                    remoteOperation.insert(art1);
                    clear();
                    GetAllArticle();
                    //MetroMessageBox.Show(this, "Insertion terminée avec succé", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Sheck your intry data please", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try

            {
                
                if (remoteOperation != null)
                {
                    art1 = new article();
                    art1 = remoteOperation.lookup(Convert.ToInt32(metroTextBox10.Text));

                    clear();

                    t.Rows.Add(art1.Codearticle, art1.Titrearticle, art1.Typearticle, art1.FraisSoumission, art1.NombrePage);
                    metroGrid1.DataSource = t;

                    metroTextBox6.Enabled = true;
                    metroTextBox7.Enabled = true;
                    metroTextBox8.Enabled = true;
                    metroTextBox9.Enabled = true;

                    metroButton7.Enabled = true;
                    metroButton6.Enabled = true;

                    metroCheckBox1.Enabled = true;
                    metroCheckBox2.Enabled = true;
                    metroCheckBox3.Enabled = true;
                    metroCheckBox4.Enabled = true;
                    //MetroMessageBox.Show(this, "oki ", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Sheck your inserted code please", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            art1 = new article();
            int rang = 0;
            art1.Codearticle = Convert.ToInt32(metroTextBox10.Text);
            try
            {
                if (metroCheckBox1.Checked)
                {
                    art1.Titrearticle = metroTextBox9.Text;
                    rang++;
                }
                if (metroCheckBox2.Checked)
                {
                    art1.Typearticle = metroTextBox8.Text;
                    rang++;
                }
                if (metroCheckBox3.Checked)
                {
                    art1.FraisSoumission = Convert.ToInt32(metroTextBox7.Text);
                    rang++;
                }
                if (metroCheckBox4.Checked)
                {
                    art1.NombrePage = Convert.ToInt32(metroTextBox6.Text);
                    rang++;
                }
                remoteOperation.update(art1, rang);
                clear();
                GetAllArticle();
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (remoteOperation != null)
                {
                    remoteOperation.remove(Convert.ToInt32(metroTextBox15.Text));
                    clear();
                    GetAllArticle();
                    if (L.Count == 0) MetroMessageBox.Show(this, "there is no data in the BD", "1111MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Sheck your Inserted Code please", "MetroMessagebox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //throw;
            }
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            metroTextBox10.Text = "Code";
            metroTextBox9.Text = "Nouveau Titre";
            metroTextBox8.Text =  "Nouveau Type";
            metroTextBox7.Text =  "Nouveau Frais Soumiss";
            metroTextBox6.Text = "Nouveau Nbre de page";


        }
    }
}
