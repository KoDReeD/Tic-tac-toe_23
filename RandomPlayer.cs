using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki
{
    internal class RandomPlayer : ComputerPlayer
    {
        public RandomPlayer(Board.Piese piese) : base(piese)
        {

        }
        Random random = new Random();
        public override void MakeMove(Board board)
        {
            link1:
            int cell = random.Next(0, 9);
            if(board.isLegal(cell))
            {
                board.MakeMove(Piese, cell);
            }
            else
            {
                goto link1;
            }
        }
    }
}
