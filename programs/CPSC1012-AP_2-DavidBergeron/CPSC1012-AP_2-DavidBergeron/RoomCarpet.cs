using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_2_DavidBergeron
{
    class RoomCarpet
    {
        private double mCarpetCost;
        private RoomDimension mSize;

        public double CarpetCost
        {
            get => mCarpetCost;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Error: Value must be >= 0.");
                }
                else
                {
                    mCarpetCost = value;
                }
            }
        }

        public RoomDimension Size 
        {
            get => mSize;
            set
            {
                if (value == null)
                {
                    throw new Exception("Room Dimension object can not be null!");
                }
                else
                {
                    mSize = value;
                }
            }
        }

        public RoomCarpet(RoomDimension dim, double cost)
        {
            Size = dim;
            CarpetCost = cost;
        }

        public double TotalCost()
        {
            return Size.Area() * CarpetCost;
        }

        public override string ToString()
        {
            return $"The total cost of the carpet is {TotalCost():C}";
        }
    }
}
