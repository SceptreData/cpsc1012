using System;
using System.Collections.Generic;
using System.Text;

namespace DiceApp
{
    public class Die
    {
        private int mSides;
        private int mValue;
        private static Random numGen = new Random();

        public int Value
        {
            get => mValue;
        }

        public int Sides
        {
            get => mSides;
        }

        public Die(int numSides)
        {
            mSides = numSides;
            this.Roll();
        }

        public void Roll()
        {
            mValue = numGen.Next(1, mSides + 1);
        }

    }
}
