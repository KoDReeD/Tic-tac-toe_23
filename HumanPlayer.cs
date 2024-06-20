using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki
{
    class HumanPlayer : Player
    {
        public HumanPlayer(string name, Board.Piese piese) : base(name, piese)
        { 

        }

        public override void MakeMove(Board board)
        {
            while (true)
            {
                Console.WriteLine("В ведите номер клетки, куда хотите поместить фигуру");
                try
                {
                    int cell = int.Parse(Console.ReadLine());
                    cell--;
                    if (board.isLegal(cell))
                    {
                        board.MakeMove(Piese, cell);
                        Console.WriteLine(board.ToString()); 
                        link1:
                        Console.WriteLine("Хотите отменить ход (да/нет)?");
                        string answer = Console.ReadLine().ToLower();
                        if(answer == "да")
                        {
                            board.UndoMove(cell);
                            Console.WriteLine(board.ToString());
                            continue;
                        }
                        else if(answer == "нет")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ответ указан не верно, повторите попытку");
                            goto link1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Клетка занята");
                        Console.WriteLine($"Ход игрока {Name}");
                        Console.WriteLine(board.ToString());
                    }
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("Номер клетки введён не корректно, укажите целое число в диапазоне(1-9)");
                    Console.WriteLine($"Ход игрока {Name}");
                    Console.WriteLine(board.ToString());
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Номер клетки введён не правильно, диапазон(1-9)");
                    Console.WriteLine($"Ход игрока {Name}");
                    Console.WriteLine(board.ToString());
                }
            }

        }
    }
}
