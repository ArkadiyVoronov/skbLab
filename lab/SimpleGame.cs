using System;
using System.Collections;
using System.Text;

namespace Kontur
{
    public class SimpleGame : IGame
    {
        protected int[] tiles;
        protected int[] positions;
        protected int sideSize;

        public int SideSize
        {
            get
            {
                return sideSize;
            }

            protected set
            {
                sideSize = value;
            }
        }

        public SimpleGame(params int[] tiles)
        {
            SideSize = (int)Math.Sqrt(tiles.Length);
            if (SideSize * SideSize != tiles.Length)
            {
                throw new InvalidOperationException("Поле игры должны быть квадратным");
            }
            bool[] existElement = new bool[tiles.Length];
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i] >= tiles.Length || tiles[i] < 0)
                    throw new ArgumentException("Не допустимое значение поля.");
                existElement[tiles[i]] = true;
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                if (!existElement[i])
                    throw new ArgumentException("Не допустимое значение поля.");
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
            if (tile > tiles.Length - 1)
                throw new ArgumentOutOfRangeException("Плитка отсутствует на карте.");
            return positions[tile];
        }
     
        public virtual int this[int x, int y]
        {
            get
            {
                if(x >= sideSize || y >= sideSize || x < 0 || y < 0)
                    throw new ArgumentOutOfRangeException("Координаты находятся вне карты.");
                return tiles[SideSize * x + y];
            }
        }

        public virtual IGame Shift(int tile)
        {
            if (tile < 1 || tile > SideSize * SideSize - 1)
            {
                throw new InvalidOperationException("Не верное значение.");
            }
            int zeroPos = GetLocation(0);
            int zeroX = zeroPos / SideSize;
            int zeroY = zeroPos % SideSize;

            int valPos = GetLocation(tile);
            int valX = valPos / SideSize;
            int valY = valPos % SideSize;

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
        public override string ToString()
        {
            StringBuilder  res = new StringBuilder("");
            for (int i = 0; i < this.SideSize; i++)
            {
                for (int j = 0; j < this.SideSize; j++)
                    res.Insert(res.Length, this[i, j] + " ");
                res.Insert(res.Length, '\n');
            }
            return res.ToString();
        }
    }
    
}
