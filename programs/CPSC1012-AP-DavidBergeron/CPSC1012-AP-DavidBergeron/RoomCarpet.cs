using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_DavidBergeron
{
    class RoomCarpet
    {
        private double _carpetCost;
        private RoomDimension _roomDimension;

        public double Cost
        {
            get => _carpetCost;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Error: Value must be >= 0.");
                } else
                {
                    _carpetCost = value;
                }
            }
        }

        public RoomCarpet(RoomDimension rd, double cost)
        {
            this._roomDimension = rd;
            this.Cost = cost;
        }

        public double TotalCost()
        {
            return _roomDimension.Area() * _carpetCost;
        }

        public string DimensionString
        {
            get => _roomDimension.ToString();
        }

        public override string ToString()
        {
            return $"The total cost of the carpet is {this.TotalCost():C}";
        }
    }
}
