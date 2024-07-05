using System;
using System.Collections.Generic;

namespace CartLibrary
{
    public class Cart
    {
        private List<Product> products = new List<Product>();
        private bool hasFreeShipping = false;

        public void AddProduct(Product product)
        {
            if (products.Count >= 100)
            {
                throw new InvalidOperationException("Cart can't contain more than 100 items");
            }

            if (product.Stock > 0)
            {
                products.Add(product);
                product.DecreaseStock();

                if (product.IsSpecial)
                {
                    hasFreeShipping = true;
                }
            }
        }

        public double GetTotalPrice()
        {
            if (products.Count == 0)
            {
                return 0;
            }

            double total = 0;
            bool hasOnlyBooks = true;

            foreach (var product in products)
            {
                total += product.Price;
                if (!product.IsBook)
                {
                    hasOnlyBooks = false;
                }
            }

            if (hasOnlyBooks)
            {
                total *= 0.9;
            }

            total *= 1.05;

            return total;
        }

        public bool HasFreeShipping()
        {
            return hasFreeShipping;
        }
    }
}
