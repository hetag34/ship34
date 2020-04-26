using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    [Serializable]
    
    public sealed class GamePageData
    {
        public readonly BoardPlacementData boardPlacementData;

        private int currTimeSec; 
        private int currTimeMin;
        private int currTimeHour; 

        private int turnCount;

       
        public readonly Board playerBoard;
        
        public readonly Board aiBoard;

        public readonly Ai ai;

        public GamePageData(BoardPlacementData boardPlacementData, int currTimeSec, int currTimeMin, int currTimeHour, int turnCount, Board playerBoard, Board aiBoard, Ai ai)
        {
            
            if(boardPlacementData == null)
            {
                throw new ArgumentException("boardPlacementData cannot be null");
            }
            else if(currTimeSec < 0 || currTimeMin < 0 || currTimeHour < 0)
            {
                throw new ArgumentException("Один из счетчиков времени отрицательный, все они должны быть положительными");
            }
            else if(turnCount < 0)
            {
                throw new ArgumentException("число оборотов не может быть отрицательным");
            }
            else if(playerBoard == null || aiBoard == null)
            {
                throw new ArgumentException("Обе платы не");
            }
            else if(ai == null)
            {
                throw new ArgumentException("the ai cannot be null");
            }

            this.boardPlacementData = boardPlacementData;
            this.currTimeHour = currTimeHour;
            this.currTimeMin = currTimeMin;
            this.currTimeSec = currTimeSec;
            this.turnCount = turnCount;
            this.playerBoard = playerBoard;
            this.aiBoard = aiBoard;
            this.ai = ai;
        }

        /* All getters and setters */

        public void setTime(int currTimeSec, int currTimeMin, int currTimeHour)
        {
            if (currTimeSec < 0 || currTimeMin < 0 || currTimeHour < 0)
            {
                throw new ArgumentException("One of the time counter is negative, they should all be positive");
            }

            this.currTimeSec = currTimeSec;
            this.currTimeMin = currTimeMin;
            this.currTimeHour = currTimeHour;
        }

        public int getTimeSec()
        {
            return this.currTimeSec;
        }

        public int getTimeMin()
        {
            return this.currTimeMin;
        }

        public int getTimeHour()
        {
            return this.currTimeHour;
        }

        public void setTurnCount(int turnCount)
        {
            if (turnCount < 0)
            {
                throw new ArgumentException("the number of turns cannot be negative");
            }

            this.turnCount = turnCount;
        }

        public int getTurnCount()
        {
            return this.turnCount;
        }
    }
}
