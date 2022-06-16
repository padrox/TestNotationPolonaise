/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
        static double Polonaise(string formule)
        {
            //création du vecteur à partir de la chaine
            String[] vec = formule.Split(' ');
            // variable contenant la longueur de la chaine
            int nbCase = formule.Length;
            //boucle de lecture de la formule
            while (nbCase>1)
            {
                //recherche de signe dans la formule
                int k = nbCase - 1;
                while (k > 0 && vec[k] != "+" && vec[k] != "-" && vec[k] != "/" && vec[k] != "*")
                {
                    k--;
                }
                // déclaration des membres de l'expression à calculer
                double a = double.Parse(vec[k + 1]);
                double b = double.Parse(vec[k + 2]);
                double resultat = 0;
                //calcul
                switch (vec[k])
                {
                    case "+":
                        resultat = a + b;
                        break;
                    case "-":
                        resultat = a - b;
                        break;
                    case "*":
                        resultat = a * b;
                        break;
                    case "/":
                        if (b==0)
                        {
                            return double.NaN;
                        }
                        resultat = a / b;
                        break;
                }
                // assigner le resultat dans la case du signe
                vec[k] = resultat.ToString();
                //déplacer les case vers la gauche
                for (int j = k+1; j> nbCase-2;j++ )
                {
                    vec[j] = vec[j + 2];
                }
                //vider les 2 dernières cases
                



            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
