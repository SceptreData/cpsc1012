using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_2_DavidBergeron
{
    public class RoomDimension
    {
        private double mLength;
        private double mWidth;

        double Length
        {
            get => mLength;
            set => mLength = value;
        }

        double Width
        {
            get => mWidth;
            set => mWidth = value;
        }

        public RoomDimension() { }

        public RoomDimension(double length, double width)
        {
            mLength = length;
            mWidth = width;
        }

        public double Area()
        {
            return mLength * mWidth;
        }

        public override string ToString()
        {
            return $"Length = {mLength}, Width = {mWidth}, Area = {this.Area()}";
        }
    }
}
