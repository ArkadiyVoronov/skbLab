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
        public MemoryLimitGame(params int[] values)
        {
            game = new SimpleGame(values);
            changes = new LinkedList<int>();
        }

        private MemoryLimitGame(SimpleGame game, LinkedList<int> changes, int value)
        {
            this.game = game;
            this.changes = new LinkedList<int>();
            foreach (var change in changes)
            {
                this.changes.AddLast(change);
            }
            this.changes.AddLast(value);
        }

        public override Object Shift(int value)
        {
            MemoryLimitGame dekor = new MemoryLimitGame(game, changes, value);
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
                int value = game[x, y];
                for (var node = changes.Last; node != null; node = node.Previous)
                {
                    game.Shift(node.Value);
                }
                return value;
            }
            
        }

        public override int GetLocation(int value)
        {
            foreach (var change in changes)
            {
                game.Shift(change);
            }
            int location = game.GetLocation(value);
            for (var node = changes.Last; node != null; node = node.Previous)
            {
                game.Shift(node.Value);
            }
            return location;
        }
    }
}
