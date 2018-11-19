using System;
using System.Collections.Generic;
using System.Text;

namespace CPSC1012_AP_DavidBergeron
{
    class RoomCarpet : RoomDimension
    {
        private double _carpetCost;

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
            this._rd = rd;
            this.Cost = cost;
        }

        public string DimensionString
        {
            get => _rd.ToString();
        }

    }
}
