using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur
{
    public class ImmutableGame : SimpleGame
    {
        public ImmutableGame(params int[] values) : base(values)
        {
        }
        new public ImmutableGame Shift(int value)
        {
            ImmutableGame game = new ImmutableGame(base.values);
            base.Shift(value);
            return game;
        }

    }
}
