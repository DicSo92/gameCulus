using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameculus
{
    enum CHOICES
    {
        EASY,
        MODERATE,
        DIFFICULT,
        CHANGE,
        SCORES,
        QUIT
    };
    class Program
    {
        private static Level s_Level;
        static void Main(string[] args)
        {
            CHOICES s_iChoiceUser;
            Console.WriteLine("Choisissez une des options ci-dessous");
            Console.WriteLine("1- commencer une partie facile");
            Console.WriteLine("2- commencer une partie moderee");
            Console.WriteLine("3- commencer une partie facile");
            Console.WriteLine("4- changer de joueur");
            Console.WriteLine("5- voir les scores");
            Console.WriteLine("6- quitter");
            s_iChoiceUser = (CHOICES)(Int32.Parse(Console.ReadLine()) - 1);


            switch (s_iChoiceUser)
            {
                case CHOICES.EASY:
                case CHOICES.MODERATE:
                case CHOICES.DIFFICULT:
                    s_Level = new Level(s_iChoiceUser);
                    startLevel();
                    break;
                case CHOICES.CHANGE:
                    break;
                case CHOICES.SCORES:
                    break;
                case CHOICES.QUIT:
                    break;
                default:
                    break;
            }
        }

        private static void startLevel()
        {
            int iScore = s_Level.start();

        }
    }
}