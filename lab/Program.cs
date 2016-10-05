using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur
{
    class Program
    {
        static void Main(string[] args)
        {
            IGame game = new ImmutableGame(0, 1, 2, 3);
            Console.WriteLine(game.ToString());
            return;
        }
    }
}
