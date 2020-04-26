using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BattleShip
{
   
    class Narrator
    {
        
        public static void displayIntro(TextBlock msgTxt)
        {
            string text = "Добро пожаловать на боевой корабль." + "\n"
                + "Я не думаю, что мы встречались раньше..." + "\n"
                + "Как тебя зовут?";
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 3));
        }

        
        public static void displayNameFoundSaved(TextBlock msgTxt, string name)
        {
            string text = name + " А вот и ты!" + "\n"
                + "Мы ждали этого целую вечность..." + "\n"
                + "Не хотите ли вы продолжить с того места на котором остановились?";
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 3));
        }

        
        public static void displayNameFound(TextBlock msgTxt, string name)
        {
            string text = name + ", вот вы где" + "\n"
                + "На каком уровне вы хотели бы играть в этот раз?";
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 3));
        }
		
		public static void newName(TextBlock msgTxt, string name)
		{
			string text = "Hi " + name + "\n Это ваш  первый раз, когда вы играете?";

			Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 3));
		}

		
		public static void placing(TextBlock msgTxt, string name)
		{
			string text =("Давайте продолжим " + name + ". Нажмите на корабль, чтобы выбрать его. После выбора используйте клавиши со стрелками для перемещения его." +
                "\n Если место  корабля вас не устраивает, двойной щелчок по нему приведет к его вращению." +
                 "\n Если вы чувствуете себя безрассудным, вы можете перетасовать доску");

			Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
		}

       
        public static void startplaying(TextBlock msgTxt, string name)
        {
            string text = ("Очень хорошо. Большая доска-это ваш противник. выберите квадрат, чтобы выстрелить в него. Если вас смущают эти четкие инструкции, " +
                "исследование правил игры \"Battleship\" они помогут вам. ");

            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
        }

        
        public static void firstturn(TextBlock msgTxt, string name)
        {
            string text = ("Вы только что стреляли в первый раз в этой игре! Я бы поздравил вас, но обезьяна могла бы сделать то же самое...");
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
        }

        
        public static void secondturn(TextBlock msgTxt, string name)
        {
            string text = ("Похоже, вы уже освоились с этим делом. Я сейчас же отключусь, если вам больше не понадобится моя помощь. ");
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
        }


       
        public static void timedout(TextBlock msgTxt, string name)
        {
            string text = ("Должен признаться, вы произвели на меня впечатление. Никогда за свою короткую искусственную жизнь я не видел, чтобы кто-то отсчитывал время по таймеру" +
                " они сами себя создали.");
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
        }

        
        public static void shipdown(TextBlock msgTxt, string name)
        {
            string text = ("Ух ты! . ты убил свой первый корабль. " +
                " the same.");
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
        }

        
        public static void normal(TextBlock msgTxt, string name)
        {
            string text = ("Ну, ты, кажется, уже все понял. На этот раз я действительно уезжаю навсегда. .");
            Animations.TypeWriter(text, msgTxt, new TimeSpan(0, 0, 4));
        }

        
        public static void youWin(TextBlock textBlock, string name)
        {
            string victoryText = name + ", ты победил...Люди 1 Компьютеры 0";
            Animations.TypeWriter(victoryText, textBlock, new TimeSpan(0, 0, 4));
        }

        public static void youLost(TextBlock textBlock, string name)
        {
            string victoryText = "Ты проиграл? Я рассчитал 100% вероятность того, что ты проиграешь. Меня это не удивляет , " + name + ".";
            Animations.TypeWriter(victoryText, textBlock, new TimeSpan(0, 0, 4));
        }

    }
}
