using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    [Serializable]
    
    public sealed class StartPageData
    {
        private readonly string playerName;

        public StartPageData(string playerName)
        {
            
            if (playerName == null || playerName.Trim().Length == 0 || playerName.Length > 20)
            {
                this.playerName = "без именни";

            }
            else
            {
                this.playerName = playerName;
            }

        }

       
        public string getPlayerName()
        {
            return this.playerName;
        }
    }
}
