namespace CartLibrary
{
    public class Product
    {
        public double Price { get; private set; }
        public int Stock { get; private set; }
        public bool IsSpecial { get; private set; }
        public bool IsBook { get; private set; }

        public Product(double price, int stock = 0, bool isSpecial = false, bool isBook = false)
        {
            Price = price;
            Stock = stock;
            IsSpecial = isSpecial;
            IsBook = isBook;
        }

        public void DecreaseStock()
        {
            if (Stock > 0)
            {
                Stock--;
            }
            else
            {
                throw new InvalidOperationException("Product is out of stock");
            }
        }
    }
}
