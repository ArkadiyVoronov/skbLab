using System;
using System.Collections;

namespace Kontur
{
    public class SimpleGame : IGame
    {
        protected int[] tiles;
        protected int[] positions;
        protected int sideSize;

        public SimpleGame(params int[] tiles)
        {
            sideSize = (int)Math.Sqrt(tiles.Length);
            if (sideSize * sideSize != tiles.Length)
            {
                throw new InvalidOperationException("Поле игры должны быть квадратным");
            }
            this.tiles = new int[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
                this.tiles[i] = tiles[i];
            positions = new int[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
            {
                positions[tiles[i]] = i;
            }
        }

        public virtual int GetLocation(int tile)
        {
            return positions[tile];
        }
     
        public virtual int this[int x, int y]
        {
            get { return tiles[sideSize * x + y]; }
        }

        public virtual IGame Shift(int tile)
        {
            if (tile < 1 || tile > sideSize * sideSize - 1)
            {
                throw new InvalidOperationException("Не верное значение.");
            }
            int zeroPos = GetLocation(0);
            int zeroX = zeroPos / sideSize;
            int zeroY = zeroPos % sideSize;

            int valPos = GetLocation(tile);
            int valX = valPos / sideSize;
            int valY = valPos % sideSize;

            if (Math.Abs(valX - zeroX) + Math.Abs(valY - zeroY) == 1)
            {
                tiles[zeroPos] = tile;
                tiles[valPos] = 0;
                positions[0] = valPos;
                positions[tile] = zeroPos;
                return this;
            }
            else
            {
                throw new InvalidOperationException("Нет соседней свободной клетки");
            }
        }

        public void Print()
        {
            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                    Console.Write(this[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    
}
