using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    [Serializable]
    public class Square
    {
        private readonly int xCoordinate;
        private readonly int yCoordinate;
        private Ship shipThere;
        private bool hasBeenShot;

        public Square(int xCoordinate, int yCoordinate) : this(xCoordinate, yCoordinate, null) { }

        public Square(int xCoordinate, int yCoordinate, Ship shipThere)
        {
            if(xCoordinate > BoardLimit.Get().maxX() || xCoordinate < BoardLimit.Get().minX())
            {
                throw new ArgumentException("параметры Х координат  (" + xCoordinate + ")должны быть включительно между "
                    + BoardLimit.Get().minX() + " и " + BoardLimit.Get().maxX());
            }
            else if (yCoordinate > BoardLimit.Get().maxY() || yCoordinate < BoardLimit.Get().minY())
            {
                throw new ArgumentException("параметры Y (" + yCoordinate + ")должны быть включительно между "
                    + BoardLimit.Get().minY() + " и " + BoardLimit.Get().maxY());
            }
            else
            {
                this.xCoordinate = xCoordinate;
                this.yCoordinate = yCoordinate;
                this.hasBeenShot = false;
                this.shipThere = shipThere;
            }
        }

        public Square(Square square)
        {
            this.xCoordinate = square.xCoordinate;
            this.yCoordinate = square.yCoordinate;
            this.shipThere = square.shipThere;
            this.hasBeenShot = square.hasBeenShot;
        }

        public Square placeShipOnto(Ship ship)
        {
            Square toReturn = new Square(this);
            toReturn.shipThere = ship;
            return toReturn;
        }

        public int getX()
        {
            return this.xCoordinate;
        }

        public int getY()
        {
            return this.yCoordinate;
        }

        public bool Equals(Square obj)
        {
            return this.xCoordinate == obj.xCoordinate && this.yCoordinate == obj.yCoordinate;
        }

        public bool shoot()
        {
            if(hasBeenShot)
            {
                throw new NotSupportedException("Нельзя снимать уже снятый квадрат");
            }

            this.hasBeenShot = true;

            if (isShip())
            {
                return this.shipThere.getShot(this);
            }
            else
            {
                return false;
            }
        }

        public bool isShot()
        {
            return this.hasBeenShot;
        }

        public bool isShip()
        {
            return !(this.shipThere == null);
        }

        public override String ToString()
        {
            return this.xCoordinate + "," + this.yCoordinate + " :\n"
                + ((this.isShip())?(""):("нет")) + "Корабль там\n"
                + "Имеет " + ((this.hasBeenShot)?(""):("нет")) + "был застрелян";
        }

        public bool hasShipSunk()
        {
            if(!this.isShip())
            {
                throw new NotSupportedException("Там нет никакого корабля");
            }
            return this.shipThere.getIsSunk();
        }
    }
}
