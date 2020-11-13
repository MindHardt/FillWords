using FillWordsData;
using System;

namespace FillWords
{
    class Program
    {
        static int activeScreen = 1;
        static void Main(string[] args)
        {
            Console.Title = "FillWords by Un1ver5e";
            Console.SetWindowSize(83, 40);
            Console.SetBufferSize(83, 40);
            MainMenuScreen MainMenu1 = new MainMenuScreen();
            InitializeScreen(MainMenu1, 4, 1);
            NewGameScreen NewGameMenu1 = new NewGameScreen();
            InitializeScreen(NewGameMenu1, 2, 2);
            while (true)
            {
                DrawNeeded(activeScreen, MainMenu1, NewGameMenu1);
                ConsoleKey CK = Console.ReadKey(true).Key;
                switch (activeScreen)
                {
                    case 1:
                        MainMenu1.Scroll(CK, MainMenu1);
                        if (CK == ConsoleKey.Enter) ExecuteButtonAction(MainMenu1);
                        break;
                    case 2:
                        NewGameMenu1.Scroll(CK, NewGameMenu1);
                        if (CK == ConsoleKey.Enter) ExecuteButtonAction(NewGameMenu1);
                        break;
                    default: break;
                }
            }


        }
        static void DrawNeeded(int screen, MainMenuScreen MainMenu1, NewGameScreen NewGameMenu1)
        {
            switch (screen)
            {
                case 1:
                    MainMenu1.Draw();
                    break;
                case 2:
                    NewGameMenu1.Draw();
                    break;


                default: break;

            }
        }
        static void ExecuteButtonAction(Screen Screen)
        {
            if (Screen.ID == 1)
            {
                switch (Screen.selectedRow)
                {
                    case 1:
                        Console.Clear();
                        activeScreen = 2;
                        break;
                    case 2:
                        Console.WriteLine("ЗДЕСЬ СКОРО ЧТО-ТО БУДЕТ!");
                        break;
                    case 3:
                        Console.WriteLine("ЗДЕСЬ СКОРО ЧТО-ТО БУДЕТ!");
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
            if (Screen.ID == 2)
            {
                switch (Screen.selectedRow)
                {
                    case 1:
                        Console.SetCursorPosition(59, 3);
                        Console.Write(">> ");
                        Console.CursorVisible = true;
                        string name = Console.ReadLine();
                        Console.CursorVisible = false;
                        Environment.Exit(0);
                        break;
                    case 2:
                        Console.Clear();
                        activeScreen = 1;
                        break;
                }
            }

        }
        static void InitializeScreen(Screen Screen, int maxRow, int ID)
        {
            Screen.maxRow = maxRow;
            Screen.selectedRow = 1;
            Screen.ID = ID;
        }

    }


}
