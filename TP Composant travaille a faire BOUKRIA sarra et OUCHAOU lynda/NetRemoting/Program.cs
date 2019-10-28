using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using ComposantArticle;
using ComposantBD;
using ComposantProceeding;

namespace NetRemoting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Création d'un nouveau canal d'écoute sur le port 1069
                TcpChannel channel = new TcpChannel(1069);
                // Enregistrement du canal
                ChannelServices.RegisterChannel(channel);
                // Démarrage de l'écoute en exposant l'objet en Singleton
                RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(RemoteOperations), "RemoteOperation",
                WellKnownObjectMode.Singleton);
                Console.WriteLine("Le serveur a démarré avec succés");

                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Erreur lors du démarrage du serveur");
                Console.ReadLine();
            }
        }
    }
}
