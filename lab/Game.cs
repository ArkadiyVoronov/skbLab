using System;
using System.Collections;

namespace Simple
{
    public class Game
    {
        int[] values;
        int[] positions;
        int sideSize;
        int GetLocation(int value)
        {
            return positions[value];
        }
        public Game(params int[] values)
        {
            sideSize = (int)Math.Sqrt(values.Length);
            this.values = values;
            positions = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                positions[values[i]] = i; 
            }            
        }
        public int this[int x, int y]
        {
            get { return values[sideSize * x + y]; }
            private set {
                values[sideSize * x + y] = value;
                positions[value] = sideSize * x + y;
            }
        }        
        public void Shift(int value)
        {
            int zeroPos = GetLocation(0);
            int zeroX = zeroPos / sideSize;
            int zeroY = zeroPos % sideSize;

            int valPos = GetLocation(value);
            int valX = valPos / sideSize;
            int valY = valPos % sideSize;

            if (Math.Abs(valX - zeroX) + Math.Abs(valY - zeroY) == 1){
                values[zeroPos] = value;
                values[valPos] = 0;
                positions[0] = valPos;
                positions[value] = zeroPos;
            }
            else{
                throw new Exception("Нет соседней свободной клетки");
            }
        }
    }
}
