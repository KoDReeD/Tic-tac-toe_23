using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki
{
    abstract class Player
    {
        public string Name { get; set; }
        public Board.Piese Piese { get; set; }

        protected Player(string name, Board.Piese piese)
        {
            Name = name;
            Piese = piese;
        }

        public abstract void MakeMove(Board board);
    }
}
