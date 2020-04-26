using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    
    public sealed class PlayerDB
    {
        private string dirPath;
        List<GamePageData> saves;

        private static readonly PlayerDB db = new PlayerDB(@"saves");

        public static PlayerDB getDB()
        {
            return PlayerDB.db;
        }

        
        private PlayerDB(string dirPath)
        {
            if(dirPath == null || dirPath.Trim().Length == 0)
            {
                throw new ArgumentException();
            }

            
            if(!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            this.dirPath = dirPath;

           
            string[] allFiles = Directory.GetFiles(this.dirPath);
            this.saves = new List<GamePageData>();
            foreach(string file in allFiles)
            {
                saves.Add(SerializeUtilities<GamePageData>.Deserialize(file));
            }
        }

        public bool isPlayerExist(string playerName)
        {
           
            string[] allFiles = Directory.GetFiles(this.dirPath);
            foreach (string file in allFiles)
            {
                
                if((this.dirPath + "\\" + playerName + ".ser").Equals(file))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isPlayerSavedInList(string playerName)
        {
            foreach(GamePageData game in this.saves)
            {
                if(game.boardPlacementData.GetStartPageData().getPlayerName().Equals(playerName))
                {
                    return true;
                }
            }
            return false;
        }

        public GamePageData loadGame(string playerName)
        {
            
            foreach (GamePageData save in this.saves)
            {
                if(save.boardPlacementData.GetStartPageData().getPlayerName().Equals(playerName))
                {
                    return save;
                }
            }

            throw new Exception(playerName + " не сохраняется игра");
        }


        public void saveGame(GamePageData save)
        {
           
            if (this.isPlayerSavedInList(save.boardPlacementData.GetStartPageData().getPlayerName()))
            {
                this.saves.Remove(save);
            }
            this.saves.Add(save);

        }

        public void saveDB()
        {
           
            foreach (GamePageData save in this.saves)
            {
               
                SerializeUtilities<GamePageData>.Serialize(save, this.dirPath + "\\" + save.boardPlacementData.GetStartPageData().getPlayerName() + ".ser");
            }
        }
    }
}
