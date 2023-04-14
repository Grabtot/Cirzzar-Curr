﻿using CirzzarCurr.Models.Enums;


namespace CirzzarCurr.Models
{
    public abstract class Product
    {
        private decimal _minimalPrice;
        public decimal MinimalPrice
        {
            get => _minimalPrice; protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _minimalPrice = value;
            }
        }
        public virtual decimal Price => _minimalPrice;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int? Size { get; set; }
        public Image? Image { get; set; }

        public ProductType Type { get; set; }
        public Product()
        {
            Name = string.Empty;
            Size = 0;
            Image = new Image<Rgba32>(1, 1);
        }
        protected Product(decimal price, string name, int? size, Image image, ProductType type)
        {
            MinimalPrice = price;
            Name = name;
            Size = size;
            Image = image;
            Type = type;
        }
        protected Product(ProductType type) : this()
        {
            Type = type;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
