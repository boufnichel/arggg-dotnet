using Xunit;
using CartLibrary;
using FluentAssertions;

namespace CartLibrary.Tests
{
    public class CartTests
    {
        [Fact]
        public void total_should_be_zero_when_no_products_in_the_bag()
        {
            Cart myCart = new Cart();
            
            myCart.GetTotalPrice().Should().Be(0);
        }

        [Fact]
        public void should_calculate_price_for_no_book()
        {
            Cart myCart = new Cart();
           
            Product product = new Product(100, 50000, false, false);
             myCart.AddProduct(product);
            
            myCart.GetTotalPrice().Should().Be(105);
        }

        [Fact]
       public void should_apply_discout_when_book_is_present()
        {
            Cart myCart = new Cart();
            Product product = new Product(100, 50000, false, true);
            myCart.AddProduct(product);
            
            myCart.GetTotalPrice().Should().Be(94.5);
        }

        [Fact]
       public void should_apply_discount_for_a_mix()
        {
            Cart myCart = new Cart();
            Product book = new Product(100, 50000, false, true);
            Product regularProduct = new Product(100, 50000, false, false);
            myCart.AddProduct(book);
            myCart.AddProduct(regularProduct);
            
            myCart.GetTotalPrice().Should().Be(210);
        }
        
        
    }
}
