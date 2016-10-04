using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur
{
    public interface IGame
    {
        int GetLocation(int tile);
        int this[int x, int y] { get; }
        IGame Shift(int tile);
    }
}
