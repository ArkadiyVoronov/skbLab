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

        private ImmutableGame(int value, int[] values) : base(values)
        {
            base.Shift(value);
        }

        public override Object Shift(int value)
        {
            ImmutableGame game = new ImmutableGame(value, base.values);
            return game;
        }
    }
}
