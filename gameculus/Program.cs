using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
        private static Player newPlayer;
        private static Player[] m_iArrayScore = new Player[5];
        private static bool keepPlaying = true;


        static void Main(string[] args)
        {
            createPlayer();

            while (keepPlaying)
            {
                displayMenu();
            }
        }
        private static void displayMenu()
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
                    createPlayer();
                    break;
                case CHOICES.SCORES:
                    displayScore();
                    break;
                case CHOICES.QUIT:
                    keepPlaying = false;
                    break;
                default:
                    break;
            }
        }


        private static void startLevel()
        {
            int iScore = s_Level.start();

            newPlayer.SetScore(iScore);

            Player currentPlayer = newPlayer.Clone();

            for (int i = 0; i < m_iArrayScore.Length; i++)
            {
                if (m_iArrayScore[i] == null || m_iArrayScore[i].GetScore() < currentPlayer.GetScore())
                {
                    if (m_iArrayScore[i] != null)
                        for (int j = m_iArrayScore.Length - 1; j > i; j--)
                            m_iArrayScore[j] = m_iArrayScore[j - 1];

                    m_iArrayScore[i] = currentPlayer;
                    break;
                }
            }
        }

        private static void displayScore()
        {
            foreach (var player in m_iArrayScore)
            {
                if (player == null)
                    break;
                Console.WriteLine("Player " + player.GetName() + " : " + player.GetScore() + " points");
            }
        }

        private static void createPlayer()
        {
            Console.WriteLine("Choose name :");
            string s_Name = Console.ReadLine();
            newPlayer = new Player(s_Name);

            Console.WriteLine("Welcome " + s_Name);
        }
    }
}