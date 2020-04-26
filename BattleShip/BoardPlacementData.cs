using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    [Serializable]
    
    public sealed class BoardPlacementData
    {
        private readonly StartPageData startPageData;

        private readonly Ship[] playerShips;
        private readonly Ship[] aiShips;

        private readonly AiLevel level;

        private readonly int idleTime;

       
        public BoardPlacementData(StartPageData startPageData, Ship[] playerShips, Ship[] aiShips, AiLevel level, int idleTime)
        {
            
            if(startPageData == null)
            {
                throw new ArgumentException("");
            }
            else if(startPageData == null || startPageData == null)
            {
                throw new ArgumentException("");
            }
            else if(idleTime < 1)
            {
                throw new ArgumentException("");
            }

            
            this.playerShips = new Ship[playerShips.Length];
            for(int i = 0; i < playerShips.Length; i++)
            {
                if(playerShips[i] == null)
                {
                    throw new ArgumentException("Корабль на " + i + " не может быть null ");
                }
                
                this.playerShips[i] = new Ship(playerShips[i]);
            }
            this.aiShips = new Ship[aiShips.Length];
            for (int i = 0; i < aiShips.Length; i++)
            {
                if (aiShips[i] == null)
                {
                    throw new ArgumentException("Корабль на " + i + " не может быть null ");
                }
                
                this.aiShips[i] = new Ship(aiShips[i]);
            }

            this.startPageData = startPageData;
            this.level = level;
            this.idleTime = idleTime;
        }

        public StartPageData GetStartPageData()
        {
            return this.startPageData;
        }

        
        public Ship[] getPlayerShip()
        {
            Ship[] toReturn = new Ship[this.playerShips.Length];
            for (int i = 0; i < this.playerShips.Length; i++)
            {
                
                toReturn[i] = new Ship(this.playerShips[i]);
            }
            return toReturn;
        }

        
        public Ship[] getAiShip()
        {
            Ship[] toReturn = new Ship[this.aiShips.Length];
            for (int i = 0; i < this.aiShips.Length; i++)
            {
                
                toReturn[i] = new Ship(this.aiShips[i]);
            }
            return toReturn;
        }

        public AiLevel getLevel()
        {
            return this.level;
        }

        public int getIdleTime()
        {
            return this.idleTime;
        }

    }
}
