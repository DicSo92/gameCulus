using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameculus
{
    class Player
    {
        private string m_sName;
        private int m_iScore;

        public Player(string p_sName)
        {
            this.m_sName = p_sName;
        }

        public Player(Player newPlayer)
        {
            m_sName = newPlayer.m_sName;
            m_iScore = newPlayer.m_iScore;
        }
        public Player Clone()
        {
            Player player = new Player(m_sName);
            player.m_iScore = m_iScore;

            return player;
        }

        public string GetName()
        {
            return m_sName;
        }

        public void SetScore (int p_iScore)
        {
            m_iScore = p_iScore;
        }

        public int GetScore ()
        {
            return m_iScore;
        }
    }
}
