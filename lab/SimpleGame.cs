﻿using System;
using System.Collections;

namespace Kontur
{
    public class SimpleGame
    {
        protected int[] values;
        protected int[] positions;
        protected int sideSize;

        public SimpleGame(params int[] values)
        {
            sideSize = (int)Math.Sqrt(values.Length);
            if (sideSize * sideSize != values.Length)
            {
                throw new Exception("Поле игры должны быть квадратным");
            }
            this.values = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
                this.values[i] = values[i];
            positions = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                positions[values[i]] = i;
            }
        }

        public virtual int GetLocation(int value)
        {
            return positions[value];
        }
     
        public virtual int this[int x, int y]
        {
            get { return values[sideSize * x + y]; }
        }

        public virtual Object Shift(int value)
        {
            if (value < 1 || value > sideSize * sideSize - 1)
            {
                throw new Exception("Не верное значение.");
            }
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
                return this;
            }
            else{
                throw new Exception("Нет соседней свободной клетки");
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
