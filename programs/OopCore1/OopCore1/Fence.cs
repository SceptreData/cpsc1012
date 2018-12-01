using System;
using System.Collections.Generic;
using System.Text;

namespace OopCore1
{
    public class Fence
    {
        private double _postSpacing = 6;
        private double _height = 6;

        private Rectangle _size = new Rectangle(1, 1);
        private Rectangle _gate = new Rectangle(1, 1);

        public double PostSpacing
        {
            get => _postSpacing;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Post spacing must be a positive value");
                }
                else
                {
                    _postSpacing = value;
                }
            }
        }

        public Rectangle Size
        {
            get => _size;
            set => _size = value;
        }

        public double Height
        {
            get => _height;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Height must be positive.");
                } else
                {
                    _height = value;
                }
            }
        }

        public Rectangle Gate
        {
            get => _gate;
            set => _gate = value;
        }


        public Fence(Rectangle size, double height)
        {
            Size = size;
            Height = height;
        }

        public double Area()
        {
            return (Size.Perimeter() - Gate.Width) * Height;
        }

        public double Perimeter()
        {
            return Size.Perimeter() - Gate.Width;
        }

        public override string ToString()
        {
            return $"Fence Square Footage: {Area()} \t Fence Perimeter: {Perimeter()}";
        }
    }
}
