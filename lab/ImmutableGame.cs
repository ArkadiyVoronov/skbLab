using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur
{
    class ImmutableGame : SimpleGame
    {
        new public ImmutableGame Shift(int value)
        {
            return this;
        }
    }
}
