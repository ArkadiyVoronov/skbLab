using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontur
{
    public class MemoryLimitGame : SimpleGame
    {
        private LinkedList<int> changes;
        private SimpleGame game;
        private MemoryLimitGame(MemoryLimitGame originalGame, int tile)
        {
            this.game = originalGame.game;
            this.changes = new LinkedList<int>(originalGame.changes);
            this.changes.AddLast(tile);
        }

        public MemoryLimitGame(params int[] tiles)
        {
            game = new SimpleGame(tiles);
            changes = new LinkedList<int>();
        }

        public override IGame Shift(int tile)
        {
            MemoryLimitGame dekor = new MemoryLimitGame(this, tile);
            foreach (var change in dekor.changes)
            {
                dekor.game.Shift(change);
            }
            for (var node = dekor.changes.Last; node != null; node = node.Previous)
            {
                dekor.game.Shift(node.Value);
            }
            return dekor;
        }

        public override int this[int x, int y]
        {
            get
            {
                foreach (var change in changes)
                {
                    game.Shift(change);
                }
                int tile = game[x, y];
                for (var node = changes.Last; node != null; node = node.Previous)
                {
                    game.Shift(node.Value);
                }
                return tile;
            }
            
        }

        public override int GetLocation(int tile)
        {
            foreach (var change in changes)
            {
                game.Shift(change);
            }
            int location = game.GetLocation(tile);
            for (var node = changes.Last; node != null; node = node.Previous)
            {
                game.Shift(node.Value);
            }
            return location;
        }
    }
}
