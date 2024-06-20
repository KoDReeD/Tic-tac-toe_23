using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki
{
    abstract class ComputerPlayer : Player
    {
        private static string name = "Computer";

        protected ComputerPlayer(Board.Piese piese) : base(name, piese)
        {

        }
    }
}
