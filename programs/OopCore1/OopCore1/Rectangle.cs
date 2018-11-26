using System;
using System.Collections.Generic;
using System.Text;

namespace OopCore1
{
    public class Rectangle
    {
        private double _length;
        private double _width;

        public double Length
        {
            get => _length;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Error: Number must be positive.");
                } else
                {
                    _length = value;
                }
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Error: Number must be positive.");
                } else
                {
                    _width = value;
                }
            }
        }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width  = width;
        }

        public double Area()
        {
            return this.Length * this.Width;
        }

        public double Perimeter()
        {
            return (this.Length * 2) + (this.Width * 2);
        }

        public override string ToString()
        {
            return $"Rectangle Length: {Length}\t Rectangle Width: {Width} \tArea: {Area()} Perimeter {Perimeter()}";
        }
    }

}
