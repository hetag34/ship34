using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BattleShip
{
    
    public partial class Game : Page
    {
        readonly GamePageData gamePageData;
        DispatcherTimer idleTimeDispatcher;
        private int currIdleTimeLeft;
        String level;
        private int currTimeSec; 
        private int currTimeMin; 
        private int currTimeHour; 
        private Boolean firstship = false;
        private Boolean silence = false;
        private int turnCount; 
        private readonly string MAGIC_WORDS = "Praise Nagi";

        public Game(GamePageData gamePageData)
        {
            this.gamePageData = gamePageData;

            startMainTimer(this.gamePageData.getTimeSec(), this.gamePageData.getTimeMin(), this.gamePageData.getTimeHour());

            InitializeComponent();

           
            initPlayerTicker(this.gamePageData.boardPlacementData.getIdleTime());

            
            this.gamePageData.playerBoard.grid = battleGrid;
            this.gamePageData.aiBoard.grid = battleGrid_Copy;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button inGrid = new Button();
                    inGrid.Click += Button_Click;

                    battleGrid.Children.Add(inGrid);
                    Grid.SetRow(inGrid, i);
                    Grid.SetColumn(inGrid, j);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button inGrid = new Button();

                    battleGrid_Copy.Children.Add(inGrid);
                    Grid.SetRow(inGrid, i);
                    Grid.SetColumn(inGrid, j);
                }
            }

            this.gamePageData.playerBoard.updateGrid();
            this.gamePageData.aiBoard.updateGrid();
        }

        public Game(BoardPlacementData boardPlacementData)
        {

            InitializeComponent();
            Narrator.startplaying(NarratorTxt, null);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button inGrid = new Button();
                    inGrid.Click += Button_Click;

                    battleGrid.Children.Add(inGrid);
                    Grid.SetRow(inGrid, i);
                    Grid.SetColumn(inGrid, j);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button inGrid = new Button();

                    battleGrid_Copy.Children.Add(inGrid);
                    Grid.SetRow(inGrid, i);
                    Grid.SetColumn(inGrid, j);
                }
            }

            Ai ai;
               level = boardPlacementData.getLevel().ToString();
           
            switch (boardPlacementData.getLevel())
            {
                case AiLevel.EASY:
                    ai = new Easy();
                    break;
                case AiLevel.MEDIUM:
                    ai = new Medium();
                    break;
                case AiLevel.HARD:
                    ai = new Hard();
                    break;
                default:
                    throw new NotSupportedException("ai unknown");
            }

            Board aiBoard = new Board(battleGrid_Copy);
            battleGrid_Copy.IsEnabled = false;
            for (int i = 0; i < boardPlacementData.getAiShip().Length; i++)
            {
                aiBoard.placeShip(new Ship(boardPlacementData.getAiShip()[i].position));
            }

            Board playerBoard = new Board(battleGrid);
            for (int i = 0; i < boardPlacementData.getPlayerShip().Length; i++)
            {
                playerBoard.placeShip(new Ship(boardPlacementData.getPlayerShip()[i].position));
            }

            this.gamePageData = new GamePageData(boardPlacementData, 0, 0, 0, 0, playerBoard, aiBoard, ai);

            initPlayerTicker(this.gamePageData.boardPlacementData.getIdleTime());

            startMainTimer(this.gamePageData.getTimeSec(), this.gamePageData.getTimeMin(), this.gamePageData.getTimeHour());

            idleTimeDispatcher.Start();
        }

        private void initPlayerTicker(int LeftidleTime)
        {
            idleTimeDispatcher = new System.Windows.Threading.DispatcherTimer();
            idleTimeDispatcher.Tick += new EventHandler(playerTurn_Tick);
           
            idleTimeDispatcher.Interval = new TimeSpan(0, 0, 1);

            
            this.currIdleTimeLeft = LeftidleTime;
        }

        private void playerTurn_Tick(object sender, EventArgs e)
        {
            
            if (--this.currIdleTimeLeft <= 0)
            {
                
                aiMove();
                if (turnCount<5 && !silence) Narrator.timedout(NarratorTxt, null);
               
                this.currIdleTimeLeft = this.gamePageData.boardPlacementData.getIdleTime();
            }
        }

        
        private void startMainTimer(int initTimeSec, int initTimeMin, int initTimeHour)
        {
            this.currTimeSec = initTimeSec;
            this.currTimeMin = initTimeMin;
            this.currTimeHour = initTimeHour;

            
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            timer.Content = getTime();
        }

        private string getTime()
        {
            if (currTimeSec >= 60)
            {
                currTimeSec = 0;
                currTimeMin++;
            }
            if (currTimeMin >= 60)
            {
                currTimeMin = 0;
                currTimeHour++;
            }
            string toReturn = ((currTimeHour != 0) ? (currTimeHour + " h ") : ("")) +
                ((currTimeMin != 0) ? (currTimeMin + " min ") : ("")) +
                ((currTimeMin != 0 && currTimeHour != 0 && currTimeSec == 0) ? ("") : (currTimeSec + " sec"));

            currTimeSec++;

            return toReturn;
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            checkWin();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (((Button)battleGrid.Children.Cast<UIElement>().First(f => Grid.GetRow(f) == i && Grid.GetColumn(f) == j)).Equals((Button)sender))
                    {
                        if (this.gamePageData.playerBoard.shoot(new Square(j, i)) && !firstship)
                        {
                           Narrator.shipdown(NarratorTxt, null);
                            firstship = true;
                           
                        }

                        this.gamePageData.playerBoard.updateGrid();

                        
                        this.currIdleTimeLeft = this.gamePageData.boardPlacementData.getIdleTime();

                        aiMove();
                    }
                }
            }
            checkWin();
        }

        
        private void aiMove()
        {
            if (turnCount == 0)
            {
                Narrator.firstturn(NarratorTxt, null);
            }
            else if (turnCount == 1)
            {
                Narrator.secondturn(NarratorTxt, null);
                
            }
            else if (turnCount>10 && !silence)
            {
                Narrator.normal(NarratorTxt, null);
                silence = true;
            }

            idleTimeDispatcher.Stop();
            battleGrid.IsEnabled = false;
            this.gamePageData.aiBoard.shoot(this.gamePageData.ai.MakeMove(this.gamePageData.aiBoard));
            this.gamePageData.aiBoard.updateGrid();
            turnCount++;
            battleGrid.IsEnabled = true;
            idleTimeDispatcher.Start();
        }

      
        private void checkWin()
        {
            if (this.gamePageData.aiBoard.isAllShipSunk() || this.gamePageData.playerBoard.isAllShipSunk())
            {
                goToScore();
            }
        }

        private void Quit()
        {
           
            updateGamePageData();

            PlayerDB.getDB().saveGame(this.gamePageData);
            MainWindow.exit();
        }

        private void goToStart()
        {
            this.NavigationService.Navigate(new StartPage());
        }

        private void goToBoatPlacement()
        {
            this.NavigationService.Navigate(new BoardPlacement(this.gamePageData.boardPlacementData.GetStartPageData()));
        }

        private void reset()
        {
            this.NavigationService.Navigate(new Game(this.gamePageData.boardPlacementData));
        }

        private void goToScore()
        {
            
            updateGamePageData();
            
            this.NavigationService.Navigate(new ScoreBoard(this.gamePageData,generatescore()));
        }

        private int generatescore()
        {
            int multiplier = 0;

            if (level == "EASY")
            {
                multiplier = 3;
            }
            else if (level == "MEDIUM")
            {
                multiplier = 2;
            }
            else if (level == "HARD")
            {
                multiplier = 1;
            }
           
            return (100000000/multiplier- (1*turnCount)) * ((this.gamePageData.aiBoard.isAllShipSunk()) ? (0) : (1));
        }

        private void updateGamePageData()
        {
            this.gamePageData.setTime(this.currTimeSec, this.currTimeMin, this.currTimeHour);
            this.gamePageData.setTurnCount(this.turnCount);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Quit();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void cheatTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cheatTxt.Text.Equals(MAGIC_WORDS))
            {
                this.gamePageData.playerBoard.isGodMode = true;
            }

            this.gamePageData.playerBoard.updateGrid();
        }
    }
}
