using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki
{
    public class Board
    {
        public Board()
        {
            Clear();
        }

        public enum Piese //фигуры
        {
            Empty,
            First,
            Second
        }

        private /*readonly*/ Piese[] _squares; //инфа о клетках

        /// <summary>
        /// перевод из enum в соответствующий символ
        /// </summary>
        /// <param name="piese">элемент enum</param>
        /// <returns>соответствующий значению enum символ</returns>
        private char ShowPiese(Piese piese)
        {
            char pieseSymbol = default;
            switch (piese)
            {
                case Piese.Empty:
                    pieseSymbol = ' ';
                    break;

                case Piese.First:
                    pieseSymbol = 'X';
                    break;

                case Piese.Second:
                    pieseSymbol = 'O';
                    break;
            }
            return pieseSymbol;
        }

        /// <summary>
        /// зомена всех элементов поля на Piese.Empty
        /// </summary>
        private void Clear()
        {
            _squares = new Piese[9];
            for (int i = 0; i < _squares.Length; i++)
            {
                _squares[i] = Piese.Empty;
            }
        }

        /// <summary>
        /// вывод поля на консоль
        /// </summary>
        /// <returns>поле в виде строки</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"+---+---+---+\n" +
                $"| {ShowPiese(_squares[0])} | {ShowPiese(_squares[1])} | {ShowPiese(_squares[2])} |\n" +
                $"+---+---+---+\n" +
                $"| {ShowPiese(_squares[3])} | {ShowPiese(_squares[4])} | {ShowPiese(_squares[5])} |\n" +
                $"+---+---+---+\n" +
                $"| {ShowPiese(_squares[6])} | {ShowPiese(_squares[7])} | {ShowPiese(_squares[8])} |\n" +
                $"+---+---+---+");
            return sb.ToString();
        }

        /// <summary>
        /// в инфу о клетках, которая хранит элементы enum добавляем фигуру
        /// </summary>
        /// <param name="piese">фигура</param>
        /// <param name="cell">индекс клетки</param>
        public void MakeMove(Piese piese, int cell)
        {
            _squares[cell] = piese;
        }

        public void UndoMove(int cell)
        {
            _squares[cell] = Piese.Empty;
        }

        public bool isLegal(int cell)
        {
            if (_squares[cell] == Piese.Empty)
            {
                return true;
            }
            else return false;
        }

        public bool isWinner(Piese piese)
        {
            int[,] winCombinations = WinCombination();

            int rows = winCombinations.GetLength(0);
            int columns = winCombinations.Length / rows;
            bool flag = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (_squares[winCombinations[i, j]] == piese)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break; //переход на след строку
                    }
                }
                if (flag)
                    break;
            }
            return flag;
        }

        public bool isFull()
        {
            bool flag = true;
            foreach (var i in _squares)
            {
                if (i == Piese.Empty) //если хоть одна клетка пустая то выйдет с false
                {
                    flag = false;
                    break;
                }

            }
            return flag;
        }

        private int[,] WinCombination()
        {
            int[,] result = new int[8, 3]
            {
                { 0, 1, 2},{ 3, 4, 5 },{ 6, 7, 8 }, { 0, 3, 6}, { 1, 4, 7}, { 2, 5, 8}, { 0, 4, 8}, { 2, 4, 6}
            };
            return result;
        }



    }
}
