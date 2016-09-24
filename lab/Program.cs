using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(0, 1, 2 ,3);
            try
            {
                game.PrintState();
                game.Shift(1);
                game.PrintState();
                game.Shift(3);
                game.PrintState();
                game.Shift(2);
                game.PrintState();
                Console.ReadKey();
                game.Shift(3);
                game.PrintState();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            
        }
    }
}
