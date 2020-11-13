using System;
using System.Data;

namespace FillWordsData
{
    public abstract class Screen
    {
        public int ID;
        public int maxRow;
        public int selectedRow;
        public abstract void Draw();
        public static void SetColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void WriteRow(string row, bool selected)
        {
            string output = String.Empty;
            for (int i = 0; i < 41 - (row.Length / 2); i++) Console.Write(" ");
            if (!selected) SetColor(); else SetColorSelected();
            Console.Write(row);
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void SetColorSelected()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Scroll(ConsoleKey CK, Screen Screen)
        {
            if ((CK == ConsoleKey.W | CK == ConsoleKey.UpArrow) & Screen.selectedRow > 1)
            {
                Screen.selectedRow -= 1;
                Console.Beep(150,250);
            }
            if ((CK == ConsoleKey.S | CK == ConsoleKey.DownArrow) & Screen.selectedRow < Screen.maxRow)
            {
                Screen.selectedRow += 1;
                Console.Beep(150,250);
            }
        }
    }
    public class MainMenuScreen : Screen
    {
        public override void Draw()
        {
            Console.SetCursorPosition(0,0);
            Console.CursorVisible = false;
            Console.WriteLine();
            SetColor();
            Console.WriteLine(" ┌─────┐ ┌───┐ ┌───┐   ┌───┐   ┌───┐   ┌───┐ ┌──────┐ ┌──────┐     ┌───┐ ┌──────┐ ");
            Console.WriteLine(" │ ┌───┘ └┐ ┌┘ └┐ ┌┘   └┐ ┌┘   └┐ ┌┘   └┐ ┌┘ │ ┌──┐ │ │ ┌──┐ │     └┐ ┌┘ │ ┌────┘ ");
            Console.WriteLine(" │ └─┐    │ │   │ │     │ │     │ │     │ │  │ │  │ │ │ └──┘ │ ┌────┘ │  │ └────┐ ");
            Console.WriteLine(" │ ┌─┘    │ │   │ │     │ │     │ │ ┌─┐ │ │  │ │  │ │ │ ┌─┐ ┌┘ │ ┌──┐ │  └────┐ │ ");
            Console.WriteLine(" │ │     ┌┘ └┐ ┌┘ └──┐ ┌┘ └──┐ ┌┘ └─┘ └─┘ └┐ │ └──┘ │ │ │ │ └┐ │ └──┘ └┐ ┌────┘ │ ");
            Console.WriteLine(" └─┘     └───┘ └─────┘ └─────┘ └───────────┘ └──────┘ └─┘ └──┘ └───────┘ └──────┘ ");
            Console.ResetColor();
            Console.WriteLine();
            WriteRow("Новая Игра", (selectedRow == 1));
            Console.WriteLine();
            WriteRow("Продолжить", (selectedRow == 2));
            Console.WriteLine();
            WriteRow("Рейтинг", (selectedRow == 3));
            Console.WriteLine();
            WriteRow("Выход", (selectedRow == 4));
        }
    }
    public class NewGameScreen : Screen
    {
        public override void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            Console.WriteLine();
            WriteRow(" Новая Игра ", false);
            Console.WriteLine();
            WriteRow(" Для продолжения введите своё имя: ", selectedRow == 1);
            Console.WriteLine();
            WriteRow("Назад", (selectedRow == 2));
        }

    }

}