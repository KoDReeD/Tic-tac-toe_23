using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki
{
    internal class Game
    {
        private Board board;
        private Player firstPlayer;
        private Player secondPlayer;
        int movesMade = 0; //сделанных ходов

        public Game()
        {
            board = new Board();
        }
        public void SelectPlayers()
        {
            Console.WriteLine("Первый игрок");
            firstPlayer = SelectPlayer(Board.Piese.First);
            Console.WriteLine("Второй игрок");
            secondPlayer = SelectPlayer(Board.Piese.Second);
        }

        private Player SelectPlayer(Board.Piese piese)
        {
            Console.WriteLine("Выберите тип игрока\n" +
                "1 - Человек\n" +
                "2 - Компьютер");
            string answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("Введите имя");
                string name = Console.ReadLine();
                return new HumanPlayer(name, piese);

            }
            else
            {
                return new RandomPlayer(piese);
            }
        }

        public void AnnounceWinner()
        {
            var win = NextPlayer().Piese;
            if (board.isWinner(win))
            {
                Console.WriteLine($"Выйграл {NextPlayer().Name}");

            }
            else if(board.isFull())
            {
                Console.WriteLine("Ничья");
            }
        }

        private bool IsRunning()
        {
            if (!board.isFull() && !board.isWinner(NextPlayer().Piese))
            {
                return true;
            }
            else
            return false;
        }

        Player NextPlayer()
        {
            Player nextPlayer = null;
            if (movesMade % 2 == 0)
                nextPlayer = firstPlayer;
            else
                nextPlayer = secondPlayer;

            return nextPlayer;
        }

        public void Play()
        {
            while(IsRunning())
            {
                var player = NextPlayer();
                Console.WriteLine($"Ход игрока {player.Name}");
                Console.WriteLine(board.ToString());
                player.MakeMove(board);
                if(!IsRunning())
                {
                    Console.WriteLine(board.ToString());
                    break;
                }
                else
                movesMade++;            
            }
            AnnounceWinner();
        }
    }
}
