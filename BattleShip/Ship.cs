using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    [Serializable]
    public class Ship
    {
        public Square[] position;
        private bool isSunk;

        public Ship(Square[] position)
        {
            if(position.Length < 2)
            {
                throw new ArgumentException("Корабль должен иметь не менее 2 квадратов");
            }

            this.position = new Square[position.Length];
            for(int i = 0; i < this.position.Length; i++)
            {
                this.position[i] = position[i].placeShipOnto(this);
            }

            this.isSunk = false;
        }

        
        public Ship(Ship toCopy)
        {
           
            this.position = new Square[toCopy.position.Length];
            for(int i = 0; i < this.position.Length; i++)
            {
                this.position[i] = toCopy.position[i];
            }
        }

        public bool getShot(Square square)
        {
            if(this.isSunk)
            {
                throw new NotSupportedException("Нельзя стрелять по затонувшему кораблю");
            }

            for(int i = 0; i < this.position.Length; i++)
            {
                if(this.position[i].Equals(square))
                {
                    this.updateIsSunk();
                    return this.isSunk;
                }
            }

            throw new ArgumentException("Этот корабль не присутствует на квадрате");
        }

        private void updateIsSunk()
        {
            for(int i = 0; i < this.position.Length; i++)
            {
                if(!this.position[i].isShot())
                {
                    return;
                }
            }

            this.isSunk = true;
        }

        public bool getIsSunk()
        {
            return this.isSunk;
        }

        public override string ToString()
        {
            String positions = "";
            foreach(Square s in this.position)
            {
                positions += s.ToString() + "\n";
            }
            return positions + "Is " + ((this.isSunk)?("мертвый") :("живой"));
        }

    }
}
