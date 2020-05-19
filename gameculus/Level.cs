using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameculus
{
    class Level
    {
        private CHOICES m_eChoiceUser;
        private int m_iMax;
        private int m_iMin;
        private string m_sText;
        private string m_sOperator;
        private int[] m_iArrayValues = new int[4];

        public Level(CHOICES p_iChoiceUser)
        {
            m_eChoiceUser = p_iChoiceUser;
        }

        internal int start()
        {
            switch (m_eChoiceUser)
            {
                case CHOICES.EASY:
                    m_iMax = 10;
                    m_iMin = 0;
                    m_sText = "addition";
                    m_sOperator = "+";
                    break;
                case CHOICES.MODERATE:
                    m_iMax = 300;
                    m_iMin = 1;
                    m_sText = "soustraction";
                    m_sOperator = "-";
                    break;
                case CHOICES.DIFFICULT:
                    m_iMax = 10;
                    m_iMin = 1;
                    m_sText = "multiplication";
                    m_sOperator = "x";
                    break;
                default:
                    break;
            }
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < m_iArrayValues.Length; i++)
            {
                m_iArrayValues[i] = rand.Next(m_iMin, m_iMax);
            }
            return play();
        }

        private int play()
        {
            Console.WriteLine("veuillez trouver le resultat de cette " + m_sText);
            int iResult = (m_eChoiceUser != CHOICES.DIFFICULT) ? 0 : 1;
            for (int i = 0; i < m_iArrayValues.Length; i++)
            {
                switch (m_eChoiceUser)
                {
                    case CHOICES.EASY:
                        iResult += m_iArrayValues[i];
                        break;
                    case CHOICES.MODERATE:
                        iResult -= m_iArrayValues[i];
                        break;
                    case CHOICES.DIFFICULT:
                        iResult *= m_iArrayValues[i];
                        break;
                }
                Console.Write((i != m_iArrayValues.Length - 1) ? (m_iArrayValues[i].ToString() + m_sOperator) : (m_iArrayValues[i].ToString() + "="));

            }
            var vStartingDate = DateTime.Now;
            int iUserResult;
            do
            {
                iUserResult = int.Parse(Console.ReadLine());
                if (iUserResult != iResult)
                    Console.WriteLine("mauvais resultat, weuillez reessayer");

            } while (iUserResult != iResult);
            return getScore(vStartingDate);
        }

        private int getScore(DateTime vStartingDate)
        {
            int iScore = (int)m_eChoiceUser + 1;
            var vTimeSpan = DateTime.Now - vStartingDate;
            Console.WriteLine("bravo votre resultat est bon");
            if (vTimeSpan.Seconds < 60)
            {
                iScore *= 60 - vTimeSpan.Seconds;
                Console.WriteLine("vous avez eu " + iScore + " points");
            }
            else
            {
                iScore = 0;
                Console.WriteLine("vous avez ete trop long");
            }
            return iScore;
        }
    }
}
