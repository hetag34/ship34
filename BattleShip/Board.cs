using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BattleShip
{
    [Serializable]
    
    public class Board
    {
        
        private Square[,] squares;
        public bool isGodMode = false;

        int available = 100;
        [NonSerialized]  public Grid grid;
        public Board(Grid grid)
        {
            int numX = BoardLimit.Get().maxX() - BoardLimit.Get().minX() + 1;
            int numY = BoardLimit.Get().maxY() - BoardLimit.Get().minY() + 1;

            this.squares = new Square[numX , numY];
            for(int i = 0; i < numX; i++)
            {
                for(int j = 0; j < numY; j++)
                {
                    this.squares[i, j] = new Square(i, j);
                }
            }

            this.grid = grid;
        }

        
        public bool isAllShipSunk()
        {
           
            foreach (Square boardSquare in this.squares)
            {
                
                if (boardSquare.isShip())
                {
                   
                    if (!boardSquare.hasShipSunk())
                    {
                        return false;
                    }
                }
            }

           
            return true;
        }

        public void placeShip(Ship toPlace)
        {
            foreach(Square ShipS in toPlace.position)
            {
                for (int i = 0; i < this.squares.GetLength(0); i++)
                {
                    for (int j = 0; j < this.squares.GetLength(1); j++)
                    {
                        if (ShipS.Equals(this.squares[j, i]))
                        {
                            if (this.squares[j, i].isShip())
                            {
                                throw new ArgumentException("Не могу поставить корабль на :\n" + this.squares[j, i].ToString());
                            }
                            else
                            {
                                this.squares[j, i] = ShipS;
                            }
                        }
                    }
                }
            }
        }

		
		public Boolean isTaken(Square space)
		{
			return this.squares[space.getX(), space.getY()].isShip();
		}


		public bool shoot(Square square)

        {
            foreach(Square s in this.squares)
            {
                bool temp;
                if (s.Equals(square))
                {
                    try
                    {
                        temp = s.shoot();
                    }
                    catch (NotSupportedException e)
                    {
                        return false;
                    }
                    available--;
                    return temp;
                }
            }

            throw new ArgumentException(square.ToString() + "\n Его нет на борту");
        }

        public void updateGrid()
        {
            for (int i = 0; i < this.squares.GetLength(0); i++)
            {
                for (int j = 0; j < this.squares.GetLength(1); j++)
                {
                    bool shot = this.squares[j, i].isShot();
                    bool ship = this.squares[j, i].isShip();

                   
                    if (shot)
                    {
                        ((Button)this.grid.Children.Cast<UIElement>().First(f => Grid.GetRow(f) == i && Grid.GetColumn(f) == j)).IsEnabled = false;

                        if(!ship)
                        {
                            ((Button)this.grid.Children.Cast<UIElement>().First(f => Grid.GetRow(f) == i && Grid.GetColumn(f) == j)).Content = "X";
                        }
                        else if(this.squares[j, i].hasShipSunk())
                        {
                            ((Button)this.grid.Children.Cast<UIElement>().First(f => Grid.GetRow(f) == i && Grid.GetColumn(f) == j)).Content = "-";
                        }
                        else
                        {
                            ((Button)this.grid.Children.Cast<UIElement>().First(f => Grid.GetRow(f) == i && Grid.GetColumn(f) == j)).Content = "Q";
                        }

                    }
                    else if(isGodMode)
                    {
                        if(ship)
                        {
                            ((Button)this.grid.Children.Cast<UIElement>().First(f => Grid.GetRow(f) == i && Grid.GetColumn(f) == j)).Content = "O";
                        }
                    }
                }
            }
        }

        public override String ToString()
        {
           

            String toReturn = "------------------------------\n";

            for (int i = 0; i < this.squares.GetLength(0); i++)
            {
                for (int j = 0; j < this.squares.GetLength(1); j++)
                {
                    bool ship = this.squares[j, i].isShip();
                    bool shot = this.squares[j, i].isShot();

                    if(!ship && !shot)
                    {
                        toReturn += "[ ]";
                    }
                    else if(!ship && shot)
                    {
                        toReturn += "[X]";
                    }
                    else if(ship && !shot)
                    {
                        toReturn += "[O]";
                    }
                    else
                    {
                        if(this.squares[j, i].hasShipSunk())
                        {
                            toReturn += "[-]";
                        }
                        else
                        {
                            toReturn += "[Q]";
                        }
                    }
                }
                toReturn += '\n';
            }
            return toReturn + "------------------------------\n";
        }
        
        public Square[] AvailableMoves()
        {
            Square[] avail = new Square[available];
            int k = 0;

            for (int i = 0; i < this.squares.GetLength(0); i++)
            {
                for (int j = 0; j < this.squares.GetLength(1); j++)
                {
                    if (!this.squares[i, j].isShot())
                    {
                        avail[k] = this.squares[i, j];
                        k++;
                    }
                }
            }
            return avail;
        }

        
        public Square[] SecondAvailableMoves()
        {
            Square[] avail = new Square[available / 2];
            int k = 0;

            for (int i = 0; i < this.squares.GetLength(0); i++)
            {
                for (int j = i % 2 == 0 ? 0 : 1; j < this.squares.GetLength(1); j+=2)
                {
                    if (!this.squares[i, j].isShot())
                    {
                        avail[k] = this.squares[i, j];
                        k++;
                    }
                }
            }
            return avail;
        }

       
        public Square[,] AllSquares()
        {
            return this.squares;
        }

        
        public bool IsShipShotNotSunk(int i, int j)
        {
            return squares[i, j].isShot() && squares[i, j].isShip() && !squares[i, j].hasShipSunk();
        }
    }
}
