using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple
{
    class Game
    {
        int sideSize;
        int[][] field;
        Location[] curNubmerPos;
        public Game(params int[] values)
        {
            sideSize = (int)Math.Sqrt(values.Length);
            field = new int[sideSize][];
            curNubmerPos = new Location[values.Length];
            for (int i = 0; i < sideSize; i++)
            {
                field[i] = new int[sideSize]; 
                for (int j = 0; j < sideSize; j++)
                {
                    field[i][j] = values[sideSize * i + j];
                    curNubmerPos[values[sideSize * i + j]] = new Location(i, j);
                }
            }
                
        }
        public void PrintState()
        {
            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public int this[int x, int y]
        {
            get { return field[x][y]; }
            set { field[x][y] = value; }
        }
        public Location GetLocation(int value)
        {
            return curNubmerPos[value];
        }
        public void Shift(int value)
        {
            Location valueLoc = GetLocation(value);
            int x = valueLoc.x;
            int y = valueLoc.y;
            bool isCorrect = false;
            if (x + 1 < sideSize && field[x + 1][y] == 0)
            {
                field[x + 1][y] = value;
                field[x][y] = 0;
                isCorrect = true;
            }
            if (x - 1 >= 0 && field[x - 1][y] == 0)
            {
                field[x - 1][y] = value;
                field[x][y] = 0;
                isCorrect = true;
            }
            if (y + 1 < sideSize && field[x][y + 1] == 0)
            {
                field[x][y + 1] = value;
                field[x][y] = 0;
                isCorrect = true;
            }
            if (y - 1 >= 0 && field[x][y - 1] == 0)
            {
                field[x][y - 1] = value;
                field[x][y] = 0;
                isCorrect = true;
            }
            if (isCorrect)
            {
                Location zeroLoc = GetLocation(0);
                curNubmerPos[0] = valueLoc;
                curNubmerPos[value] = zeroLoc;
            }
            else {
                throw new Exception("Нет соседней свободной клетки");
            }
        }
    }
    class Location
    {
        public int x, y;
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString() 
        {
            return x.ToString() + ' ' + y.ToString();
        }
    }
}
