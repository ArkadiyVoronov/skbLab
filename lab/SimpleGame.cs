using System;
using System.Collections;

namespace Kontur
{
    public class SimpleGame
    {
        protected int[] values;
        protected int[] positions;
        protected int sideSize;
        protected int GetLocation(int value)
        {
            return positions[value];
        }
        public SimpleGame(params int[] values)
        {
            sideSize = (int)Math.Sqrt(values.Length);
            this.values = new int[values.Length];
            for(int i = 0;i < values.Length; i++)
                this.values[i] = values[i];
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
