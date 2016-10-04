using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur
{
    public class ImmutableGame : SimpleGame
    {
        public ImmutableGame(params int[] tiles) : base(tiles)
        {
        }

        private ImmutableGame(int value, int[] tiles) : base(tiles)
        {
            base.Shift(value);
        }

        public override IGame Shift(int tile)
        {
            ImmutableGame game = new ImmutableGame(tile, base.tiles);
            return game;
        }
    }
}
