using System;
using System.Collections.Generic;
using System.Text;

namespace OopCore3App
{
    class Item
    {
        private string _name;
        private double _price;

        public string Name
        {
            get => _name;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                }
                else
                {
                    throw new Exception("Error: Description value is required.");
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (value >= 0)
                {
                    _price = value;
                } else
                {
                    throw new Exception("Error: Value must be greater than or equal to 0");
                }
            }
        }

        public Item(string name = "NoDescription", double price = 0)
        {
            this.Name = name;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}\t Price: {this.Price}";
        }
    }
}
